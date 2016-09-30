
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Mail.Api.Clients;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System.Linq;
using System;
using SlidingApps.TaskRunner.Foundation.Configuration;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants
{
    public class TenantService :
        ICommandHandler<TenantCommand<CreateTenant>>,
        ICommandHandler<TenantCommand<ChangeTenantInfo>>,
        ICommandHandler<TenantCommand<ConfirmTenant>>
    {
        private readonly IMediator mediator;

        private readonly IQueryProvider<ISession> queryProvider;

        private readonly IDomainEntityValidatorProvider validator;

        public TenantService(IMediator mediator, IQueryProvider<ISession> queryProvider, IDomainEntityValidatorProvider validator)
        {
            this.mediator = mediator;
            this.queryProvider = queryProvider;
            this.validator = validator;
        }

        public ICommandResult Handle(TenantCommand<CreateTenant> command)
        {
            // Create TENANT.
            Tenant tenant = new Tenant(new Entities.Tenant(), this.validator.CreateFor<Tenant>());
            tenant.AddDefaultDomain();
            TenantEvent<CreateTenant> tenantEvent = tenant.Apply(command);

            // Create ACCOUNT.
            ICommandResult accountResult = this.mediator.Send(new AccountCommand<CreateAccount>(command.Intent.UserName, new CreateAccount { EmailAddress = command.Intent.UserName }));
            AccountEvent<CreateAccount> accountEvent = accountResult.OfType<AccountEvent<CreateAccount>>().Single();

            ICommandResult userResult =
                this.mediator.Send(
                    new AccountCommand<ChangeAccountUser>(accountEvent.Key,
                        new ChangeAccountUser
                        {
                            Name = command.Intent.UserName,
                            Password = command.Intent.UserPassword
                        }));
            AccountEvent<ChangeAccountUser> userEvent = userResult.OfType<AccountEvent<ChangeAccountUser>>().Single();

            // Associate the ACCOUNT with the TENANT.
            TenantAccount tenantAccount = tenant.AddAccount(accountEvent.Identifiers.EntityId);

            // Set the new ACCOUNT as TENANT OWNER.
            TenantEvent<SetTenantOwner> roleEvent = tenantAccount.Apply(new TenantCommand<SetTenantOwner>(command.Key, new SetTenantOwner(command.Intent.UserName)));

            tenant
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            this.queryProvider.Session.Flush();

            // Delegate to the MAIL MANAGEMENT SERVICE to send an e-mail. 
            using (MailManagementClient mail = new MailManagementClient())
            {
                var link = MailUtils.GetLink(command.Intent.Code, tenant.Link);
                var url = string.Format("{0}/tenant/{1}/confirmation/{2}", SiteConfiguration.ApplicationBaseUrl, command.Intent.Code, link);
                mail.PostSendTenantConfirmationLink(new Mail.Api.Models.SendTenantConfirmationLink { Recipient = command.Intent.UserName, Code = command.Intent.Code, ConfirmationUrl = url });
            }

            // Delegate to the ACCOUNT MANAGEMENT SERVICE to send an e-mail.
            this.mediator.Send(new AccountCommand<SendConfirmationLink>(new SendConfirmationLink { Name = command.Intent.UserName }));

            return new CommandResult(command.Id,
                new IDomainEvent[]
                {
                    tenantEvent,
                    accountEvent,
                    userEvent,
                    roleEvent
                });
        }

        public ICommandResult Handle(TenantCommand<ChangeTenantInfo> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Tenant>().Where(x => x.Code == command.Key.Code).Single();
            var entity = new Tenant(existing, this.validator.CreateFor<Tenant>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(TenantCommand<ConfirmTenant> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Tenant>().Where(x => x.Code == command.Key.Code).Single();
            var entity = new Tenant(existing, this.validator.CreateFor<Tenant>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
