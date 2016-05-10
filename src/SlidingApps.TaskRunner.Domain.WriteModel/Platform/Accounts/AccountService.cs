
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System.Linq;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts
{
    public class AccountService :
        ICommandHandler<AccountCommand<CreateAccount>>,
        ICommandHandler<AccountCommand<ChangeAccountProfileName>>,
        ICommandHandler<AccountCommand<ChangeAccountUserPeriod>>,
        ICommandHandler<AccountCommand<ChangeAccountUser>>,
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
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountProfileName> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.Id == command.AccountId).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<ChangeAccountUserPeriod> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.Id == command.AccountId).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
        
        public ICommandResult Handle(AccountCommand<ChangeAccountUser> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.Id == command.AccountId).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.User.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(AccountCommand<SendResetPasswordLink> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Account>().Where(x => x.EmailAddress == command.Intent.Name || x.User.Name == command.Intent.Name).Single();
            Account entity = new Account(existing, this.validator.CreateFor<Account>());
            var result = entity.Apply(command);

            return new CommandResult(command.Id, result);
        }
    }
}
