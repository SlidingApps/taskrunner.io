
using System;
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class TenantService :
        ICommandHandler<TenantCommand<CreateTenant>>,
        ICommandHandler<TenantCommand<ChangeTenantInfo>>
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
            Tenant entity = new Tenant(new Entities.Tenant(), this.validator.CreateFor<Tenant>());
            var result = entity.Apply(command);

            ICommandResult events = this.mediator.Send(new AccountCommand<CreateTenantAdminAccount>(entity.Id, new CreateTenantAdminAccount { EmailAddress = command.Intent.UserName }));
            entity.AddAccount(events.OfType<AccountEvent<CreateTenantAdminAccount>>().Single().AccountId);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(TenantCommand<ChangeTenantInfo> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Tenant>().Where(x => x.Id == command.TenantId).Single();
            var entity = new Tenant(existing, this.validator.CreateFor<Tenant>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
