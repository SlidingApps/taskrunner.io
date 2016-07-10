
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Accounts
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

        public EntityStatus Status
        {
            get { return this.entity.Profile.Status; }
            private set { this.entity.Profile.Status = value; }
        }

        public string Link
        {
            get { return this.entity.Profile.Link; }
            private set { this.entity.Profile.Link = value; }
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

        public AccountEvent<CreateAccount> Apply(AccountCommand<CreateAccount> command)
        {
            AccountEvent<CreateAccount> domainEvent = new AccountEvent<CreateAccount>(command);
            this.When(domainEvent);

            return domainEvent;
        }
        
        public void When(AccountEvent<CreateAccount> domainEvent)
        {
            this.Id = domainEvent.Identifiers.EntityId = Guid.NewGuid();
            this.EmailAddress = domainEvent.Arguments.EmailAddress;
            this.Name = domainEvent.Arguments.Name ?? domainEvent.Arguments.EmailAddress;
            this.FirstName = domainEvent.Arguments.FirstName;
            this.Info = domainEvent.Arguments.Info;

            this.DomainEvents.Add(domainEvent);
        }

        public AccountEvent<ChangeAccountProfileName> Apply(AccountCommand<ChangeAccountProfileName> command)
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

        public AccountEvent<ChangeAccountUserPeriod> Apply(AccountCommand<ChangeAccountUserPeriod> command)
        {
            return this.User.Apply(command);
        }

        public AccountEvent<SendResetPasswordLink> Apply(AccountCommand<SendResetPasswordLink> command)
        {
            AccountEvent<SendResetPasswordLink> domainEvent = new AccountEvent<SendResetPasswordLink>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(AccountEvent<SendResetPasswordLink> domainEvent)
        {
            this.Link = Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper();

            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
