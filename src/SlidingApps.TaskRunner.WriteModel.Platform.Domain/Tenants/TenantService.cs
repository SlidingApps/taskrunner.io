﻿
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Clients;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System.Linq;

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

            // Create PERSON.
            ICommandResult accountResult = this.mediator.Send(new PersonCommand<CreatePerson>(command.Intent.UserName, new CreatePerson { EmailAddress = command.Intent.UserName }));
            PersonEvent<CreatePerson> accountEvent = accountResult.OfType<PersonEvent<CreatePerson>>().Single();

            ICommandResult userResult =
                this.mediator.Send(
                    new PersonCommand<ChangePersonUser>(accountEvent.Key,
                        new ChangePersonUser
                        {
                            Name = command.Intent.UserName,
                            Password = command.Intent.UserPassword
                        }));
            PersonEvent<ChangePersonUser> userEvent = userResult.OfType<PersonEvent<ChangePersonUser>>().Single();

            // Associate the ACCOUNT with the TENANT.
            TenantPerson tenantAccount = tenant.AddPerson(accountEvent.Identifiers.EntityId);

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
                mail.PostSendTenantConfirmationLink(new Infrastructure.Api.Models.SendTenantConfirmationLink { Recipient = command.Intent.UserName, Code = command.Intent.Code, ConfirmationUrl = url });
            }

            // Delegate to the PERSON MANAGEMENT SERVICE to send an e-mail.
            this.mediator.Send(new PersonCommand<SendConfirmationLink>(new SendConfirmationLink { Name = command.Intent.UserName }));

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
