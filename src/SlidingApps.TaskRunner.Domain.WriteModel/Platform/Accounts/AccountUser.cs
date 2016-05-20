
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Encryption;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
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

        public virtual string Salt
        {
            get { return this.entity.Salt; }
            private set { this.entity.Salt = value; }
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

        public AccountEvent<ChangeAccountUser> Apply(AccountCommand<ChangeAccountUser> command)
        {
            AccountEvent<ChangeAccountUser> domainEvent = new AccountEvent<ChangeAccountUser>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<ChangeAccountUser> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;

            var cryptor = new BlowFish(Constant.PASSWORD_ENCRYPTION_KEY);
            cryptor.IV = Constant.PASSWORD_ENCRYPTION_INIT_VECTOR.ToBytes();

            this.Salt = !string.IsNullOrEmpty(this.Salt) ? this.Salt : Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper().ToHexString();
            this.Password = cryptor.Encrypt_CBC(string.Format(Constant.PASSWORD_SALTING_TEMPLATE, domainEvent.Arguments.Password, this.Salt));

            this.DomainEvents.Add(domainEvent);
        }

        public AccountEvent<ChangeAccountUserPeriod> Apply(AccountCommand<ChangeAccountUserPeriod> command)
        {
            AccountEvent<ChangeAccountUserPeriod> domainEvent = new AccountEvent<ChangeAccountUserPeriod>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<ChangeAccountUserPeriod> domainEvent)
        {
            this.ValidFrom = domainEvent.Arguments.ValidFrom;
            this.ValidUntil = domainEvent.Arguments.ValidUntil;
            this.DomainEvents.Add(domainEvent);
        }
    }
}
