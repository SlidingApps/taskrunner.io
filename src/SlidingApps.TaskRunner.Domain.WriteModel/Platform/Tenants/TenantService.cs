
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
        // ICommandHandler<TenantCommand<CreateTenant>>,
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

        //public ICommandResultSet Handle(TenantCommand<CreateTenant> command)
        //{
        //    // Create TENANT.
        //    Tenant entity = new Tenant(new Entities.Tenant(), this.validator.CreateFor<Tenant>());
        //    TenantEvent<CreateTenant> tenantEvent = entity.Apply(command);

        //    // Create ACCOUNT.
        //    ICommandResultSet accountResult = this.mediator.Send(new AccountCommand<CreateAccount>(entity.Id, new CreateAccount { EmailAddress = command.Intent.UserName }));
        //    AccountEvent<CreateAccount> accountEvent = accountResult.OfType<AccountEvent<CreateAccount>>().Single();

        //    ICommandResultSet userResult = 
        //        this.mediator.Send(
        //            new AccountCommand<ChangeAccountUser>(accountEvent.AccountId, 
        //                new ChangeAccountUser
        //                {
        //                    Name = command.Intent.UserName,
        //                    Password = command.Intent.UserPassword
        //                }));
        //    AccountEvent<ChangeAccountUser> userEvent = userResult.OfType<AccountEvent<ChangeAccountUser>>().Single();

        //    // Associate the ACCOUNT with the TENANT.
        //    TenantAccount account = entity.AddAccount(accountEvent.AccountId);

        //    // Set the new ACCOUNT as TENANT OWNER.
        //    TenantEvent<SetTenantOwner> roleEvent = account.Apply(new TenantCommand<SetTenantOwner>(entity.Id, new SetTenantOwner(command.Intent.UserName)));

        //    entity
        //        .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
        //        .ElseThrow();

        //    return new CommandResultSet(command.Id, 
        //        new IDomainEvent[] 
        //        {
        //            tenantEvent,
        //            accountEvent,
        //            userEvent,
        //            roleEvent
        //        });
        //}

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
