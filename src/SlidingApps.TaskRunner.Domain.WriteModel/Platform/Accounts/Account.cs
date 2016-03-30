
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts
{
    public partial class Account
        : DomainEntity<Guid, Entities.Account>, IWithValidator<Account>
    {
        private readonly IValidator<Account> validator;

        public Account(Entities.Account entity, IValidator<Account> validator)
        {
            this.validator = validator;

            this.entity = entity;
            if (this.entity.Profile == null)
            {
                this.entity.Profile = new Entities.AccountProfile(Guid.NewGuid());
                this.entity.Profile.Account = this.entity;
            };
        }

        public string EmailAddress
        {
            get { return this.entity.EmailAddress; }
            private set { this.entity.EmailAddress = value; }
        }

        public string Name
        {
            get { return this.entity.Profile.Name; }
            private set { this.entity.Profile.Name = value; }
        }

        public string FirstName
        {
            get { return this.entity.Profile.FirstName; }
            private set { this.entity.Profile.FirstName = value; }
        }

        public string Info
        {
            get { return this.entity.Profile.Info; }
            private set { this.entity.Profile.Info = value; }
        }

        private AccountUser user;

        public AccountUser User
        {
            get
            {
                if (this.entity.User == null)
                {
                    this.entity.User = new Entities.AccountUser(Guid.NewGuid());
                    this.entity.User.Account = this.entity;
                };

                return this.user = new AccountUser(this.entity.User); ;
            }
            private set { this.user = value; }
        }

        public IDomainEvent Apply(AccountCommand<CreateAccount> command)
        {
            AccountEvent<CreateAccount> domainEvent = new AccountEvent<CreateAccount>(command);
            this.When(domainEvent);

            return domainEvent;
        }
        
        public void When(AccountEvent<CreateAccount> domainEvent)
        {
            this.Id = domainEvent.AccountId = Guid.NewGuid();
            this.EmailAddress = domainEvent.Arguments.EmailAddress;
            this.Name = domainEvent.Arguments.Name ?? domainEvent.Arguments.EmailAddress;
            this.FirstName = domainEvent.Arguments.FirstName;
            this.Info = domainEvent.Arguments.Info;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(AccountCommand<ChangeAccountProfileName> command)
        {
            AccountEvent<ChangeAccountProfileName> domainEvent = new AccountEvent<ChangeAccountProfileName>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<ChangeAccountProfileName> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;
            this.FirstName = domainEvent.Arguments.FirstName;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(AccountCommand<ChangeAccountUserPeriod> command)
        {
            AccountEvent<ChangeAccountUserPeriod> domainEvent = new AccountEvent<ChangeAccountUserPeriod>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<ChangeAccountUserPeriod> domainEvent)
        {
            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
