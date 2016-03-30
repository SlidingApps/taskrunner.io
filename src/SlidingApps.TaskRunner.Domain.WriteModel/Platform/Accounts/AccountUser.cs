
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts
{
    public class AccountUser
        : DomainEntity<Guid, Entities.AccountUser>
    {
        public AccountUser(Entities.AccountUser entity)
        {
            this.entity = entity;
        }

        public virtual string Name
        {
            get { return this.entity.Name; }
            private set { this.entity.Name = value; }
        }

        public virtual string Password
        {
            get { return this.entity.Password; }
            private set { this.entity.Password = value; }
        }

        public virtual DateTime ValidFrom
        {
            get { return this.entity.ValidFrom; }
            private set { this.entity.ValidFrom = value; }
        }

        public virtual DateTime ValidUntil
        {
            get { return this.entity.ValidUntil; }
            private set { this.entity.ValidUntil = value; }
        }

        public IDomainEvent Apply(AccountCommand<ChangeAccountUser> command)
        {
            AccountEvent<ChangeAccountUser> domainEvent = new AccountEvent<ChangeAccountUser>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<ChangeAccountUser> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;
            this.Password = domainEvent.Arguments.Password;
            this.DomainEvents.Add(domainEvent);
        }
    }
}
