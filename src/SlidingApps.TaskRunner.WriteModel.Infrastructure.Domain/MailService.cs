﻿
using NHibernate;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent;
using System.Linq;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain
{
    public class MailService :
        ICommandHandler<MailCommand<SendTenantConfirmationLink>>,
        ICommandHandler<MailCommand<SendAccountConfirmationLink>>,
        ICommandHandler<MailCommand<SendResetPasswordLink>>
    {
        private readonly IQueryProvider<ISession> queryProvider;

        private readonly IDomainEntityValidatorProvider validator;

        public MailService(IQueryProvider<ISession> queryProvider, IDomainEntityValidatorProvider validator)
        {
            this.queryProvider = queryProvider;
            this.validator = validator;
        }

        public const string TENANT_CONFIRMATION_LINK_TEMPLATE = "TENANT_CONFIRMATION_LINK";
        public const string ACCOUNT_CONFIRMATION_LINK_TEMPLATE = "ACCOUNT_CONFIRMATION_LINK";
        public const string RESET_PASSWORD_LINK_TEMPLATE = "RESET_PASSWORD_LINK";

        public ICommandResult Handle(MailCommand<SendTenantConfirmationLink> command)
        {
            this.SendMail(MailService.TENANT_CONFIRMATION_LINK_TEMPLATE, command);

            return new CommandResult(command.Id);
        }

        public ICommandResult Handle(MailCommand<SendAccountConfirmationLink> command)
        {
            this.SendMail(MailService.ACCOUNT_CONFIRMATION_LINK_TEMPLATE, command);

            return new CommandResult(command.Id);
        }

        public ICommandResult Handle(MailCommand<SendResetPasswordLink> command)
        {
            this.SendMail(MailService.RESET_PASSWORD_LINK_TEMPLATE, command);

            return new CommandResult(command.Id);
        }

        #region - Private & protected method  -

        private void SendMail<TMailIntent>(string templateCode, MailCommand<TMailIntent> command)
            where TMailIntent : IMailIntent
        {
            var existing = this.queryProvider.CreateQuery<Entities.MailTemplate>().Where(x => x.Code == templateCode).Single();
            var entity = new MailTemplate(existing, this.validator.CreateFor<MailTemplate>());

            command.Intent.Subject = entity.Subject;
            command.Intent.TextContentTemplate = entity.TextTemplate;
            command.Intent.HtmlContentTemplate = entity.HtmlTemplate;

            var communication = new Communication<MailCommunicationInfo>(new Entities.Communication(), this.validator.CreateFor<Communication<MailCommunicationInfo>>());
            communication.Info.Apply(command);

            this.queryProvider.Session.Save(communication.GetDataEntity());

            var response = MailGun.SendSimpleMessage(
                new MailParameters(
                    MailServiceConfiguration.Domain,
                    MailServiceConfiguration.NoreplyAddress,
                    entity.Subject,
                    communication.Info.TextContent,
                    communication.Info.HtmlContent,
                    command.Intent.Recipient)
                );

            // Deserialize the response. See MailGun docs for info: https://documentation.mailgun.com/
            dynamic content = response.Content.FromJson<dynamic>();

            communication.Info.Status = MailStatus.QUEUED;
            communication.Info.ExternalId = content.id;
            this.queryProvider.Session.Save(communication.GetDataEntity());
        }

        #endregion
    }
}
