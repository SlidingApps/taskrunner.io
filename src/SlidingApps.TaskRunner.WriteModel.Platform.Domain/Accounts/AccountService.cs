
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.ExceptionManagement;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Mail.Api.Clients;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;
using System;
using System.Linq;
using System.Web;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Accounts
{
    public class AccountService :
        ICommandHandler<AccountCommand<CreateAccount>>,
        ICommandHandler<AccountCommand<ChangeAccountProfileName>>,
        ICommandHandler<AccountCommand<ChangeAccountUserPeriod>>,
        ICommandHandler<AccountCommand<ChangeAccountUser>>,
        ICommandHandler<AccountCommand<SendConfirmationLink>>,
        ICommandHandler<AccountCommand<SendResetPasswordLink>>
    {
        private readonly IMediator mediator;

        private readonly IQueryProvider<ISession> queryProvider;

        private readonly IDomainEntityValidatorProvider validator;

        public AccountService(IMediator mediator, IQueryProvider<ISession> queryProvider, IDomainEntityValidatorProvider validator)
        {
            this.mediator = mediator;
            this.queryProvider = queryProvider;
            this.validator = validator;
        }

        public ICommandResult Handle(AccountCommand<CreateAccount> command)
        {
            Account entity = new Account(new Entities.Account(), this.validator.CreateFor<Account>());
            AccountEvent<CreateAccount> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountProfileName> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            AccountEvent<ChangeAccountProfileName> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountUserPeriod> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            AccountEvent<ChangeAccountUserPeriod> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
        
        public ICommandResult Handle(AccountCommand<ChangeAccountUser> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            AccountEvent<ChangeAccountUser> result = entity.User.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<SendConfirmationLink> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Intent.Name || x.User.Name == command.Intent.Name).SingleOrDefault();
            if (existing == null) throw new BusinessException("Unknown user account");

            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            var link = (
                    new
                    {
                        Salt = Guid.NewGuid().ToString(),
                        Username = command.Intent.Name,
                        Link = entity.Link
                    }
                ).ToJson()
                .Encrypt(EncryptionConfiguration.SymmetricKey, EncryptionConfiguration.SymmetricInitVector)
                .ToBytes()
                .ToBase58();

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            using (MailManagementClient mail = new MailManagementClient())
            {
                var url = string.Format("{0}/account/{1}/confirmation/{2}", SiteConfiguration.ApplicationBaseUrl, command.Intent.Name, link);
                mail.PostSendAccountConfirmationLink(new Mail.Api.Models.SendAccountConfirmationLink { ConfirmationUrl = url, Recipient = entity.EmailAddress, UserName = command.Intent.Name });
            }

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<SendResetPasswordLink> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Intent.Name || x.User.Name == command.Intent.Name).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            AccountEvent<SendResetPasswordLink> result = entity.Apply(command);

            var link = (
                    new {
                        Salt = Guid.NewGuid().ToString(),
                        Username = command.Intent.Name,
                        Link = entity.Link
                    }
                ).ToJson()
                .Encrypt(EncryptionConfiguration.SymmetricKey, EncryptionConfiguration.SymmetricInitVector)
                .ToBytes()
                .ToBase58();

            // Delegate to the MAIL MANAGEMENT SERVICE to send a e-mail. 
            using (MailManagementClient mail = new MailManagementClient())
            {
                var url = string.Format("{0}/account/{1}/resetpassword/{2}", SiteConfiguration.ApplicationBaseUrl, command.Intent.Name, link);
                mail.PostSendResetPasswordLink(new Mail.Api.Models.SendResetPasswordLink { ResetPasswordUrl = url, UserName = command.Intent.Name, Recipient = entity.EmailAddress });
            }

            return new CommandResult(command.Id, result);
        }
    }
}
