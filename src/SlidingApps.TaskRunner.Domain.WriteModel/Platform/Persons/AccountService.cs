
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class AccountService :
        ICommandHandler<AccountCommand<CreateAccount>>,
        ICommandHandler<AccountCommand<ChangeAccountProfileName>>,
        ICommandHandler<AccountCommand<ChangeAccountUserPeriod>>
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
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountProfileName> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.TenantId == command.TenantId && x.Id == command.AccountId).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountUserPeriod> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.TenantId == command.TenantId && x.Id == command.AccountId).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
