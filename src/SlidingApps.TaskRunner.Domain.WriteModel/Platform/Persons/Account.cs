
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class Account
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

        public Guid TenantId
        {
            get { return this.entity.TenantId; }
            private set { this.entity.TenantId = value; }
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

        public DateTime StartDate
        {
            get { return this.entity.StartDate; }
            private set { this.entity.StartDate = value; }
        }

        public DateTime EndDate
        {
            get { return this.entity.EndDate; }
            private set { this.entity.EndDate = value; }
        }

        public IDomainEvent Apply(AccountCommand<CreateAccount> command)
        {
            AccountEvent<CreateAccount> domainEvent = new AccountEvent<CreateAccount>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<CreateAccount> domainEvent)
        {
            this.Id = domainEvent.AccountId;
            this.TenantId = domainEvent.TenantId;
            this.Name = domainEvent.Arguments.Name;
            this.Info = domainEvent.Arguments.Info;
            this.FirstName = domainEvent.Arguments.FirstName;

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
            this.StartDate = domainEvent.Arguments.StartDate;
            this.EndDate = domainEvent.Arguments.EndDate;

            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
