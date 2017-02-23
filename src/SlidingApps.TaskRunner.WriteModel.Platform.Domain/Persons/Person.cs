
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons
{
    public partial class Person
        : DomainEntity<Guid, Entities.Person>, IWithValidator<Person>
    {
        private readonly IValidator<Person> validator;

        public Person(Entities.Person entity, IValidator<Person> validator)
        {
            this.validator = validator;

            this.entity = entity;
            if (this.entity.Profile == null)
            {
                this.entity.Profile = new Entities.PersonIdentity(Guid.NewGuid());
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

        public DateTime CreationTime
        {
            get { return this.entity.Profile.CreationTime; }
            private set { this.entity.Profile.CreationTime = value; }
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

        private PersonUser user;

        public PersonUser User
        {
            get
            {
                if (this.entity.User == null)
                {
                    this.entity.User = new Entities.PersonUser(Guid.NewGuid());
                    this.entity.User.Account = this.entity;
                };

                return this.user = new PersonUser(this.entity.User); ;
            }
            private set { this.user = value; }
        }

        public PersonEvent<CreatePerson> Apply(PersonCommand<CreatePerson> command)
        {
            PersonEvent<CreatePerson> domainEvent = new PersonEvent<CreatePerson>(command);
            this.When(domainEvent);

            return domainEvent;
        }
        
        public void When(PersonEvent<CreatePerson> domainEvent)
        {
            this.Id = domainEvent.Identifiers.EntityId = Guid.NewGuid();
            this.EmailAddress = domainEvent.Arguments.EmailAddress;
            this.Name = domainEvent.Arguments.Name ?? domainEvent.Arguments.EmailAddress;
            this.FirstName = domainEvent.Arguments.FirstName;
            this.CreationTime = DateTime.UtcNow;
            this.Info = domainEvent.Arguments.Info;
            this.Status = EntityStatus.UNCONFIRMED;
            this.Link = Guid.NewGuid().ToString();

            this.DomainEvents.Add(domainEvent);
        }

        public PersonEvent<ChangePersonIdentityName> Apply(PersonCommand<ChangePersonIdentityName> command)
        {
            PersonEvent<ChangePersonIdentityName> domainEvent = new PersonEvent<ChangePersonIdentityName>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<ChangePersonIdentityName> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;
            this.FirstName = domainEvent.Arguments.FirstName;

            this.DomainEvents.Add(domainEvent);
        }

        public PersonEvent<ChangePersonUserPeriod> Apply(PersonCommand<ChangePersonUserPeriod> command)
        {
            return this.User.Apply(command);
        }

        public PersonEvent<SendConfirmationLink> Apply(PersonCommand<SendConfirmationLink> command)
        {
            PersonEvent<SendConfirmationLink> domainEvent = new PersonEvent<SendConfirmationLink>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<SendConfirmationLink> domainEvent)
        {
            this.Link = Guid.NewGuid().ToString();

            this.DomainEvents.Add(domainEvent);
        }

        public PersonEvent<SendResetPasswordLink> Apply(PersonCommand<SendResetPasswordLink> command)
        {
            PersonEvent<SendResetPasswordLink> domainEvent = new PersonEvent<SendResetPasswordLink>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<SendResetPasswordLink> domainEvent)
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
