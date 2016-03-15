
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class Person
        : DomainEntity<Guid, Entities.Person>, IWithValidator<Person>
    {
        private readonly IValidator<Person> validator;

        public Person(Entities.Person entity, IValidator<Person> validator)
        {
            this.validator = validator;

            this.entity = entity;
            if (this.entity.Identity == null)
            {
                this.entity.Identity = new Entities.PersonIdentity(Guid.NewGuid());
                this.entity.Identity.Person = this.entity;
            };
        }

        public Guid TenantId
        {
            get { return this.entity.TenantId; }
            private set { this.entity.TenantId = value; }
        }

        public string Name
        {
            get { return this.entity.Identity.Name; }
            private set { this.entity.Identity.Name = value; }
        }

        public string FirstName
        {
            get { return this.entity.Identity.FirstName; }
            private set { this.entity.Identity.FirstName = value; }
        }

        public string Info
        {
            get { return this.entity.Identity.Info; }
            private set { this.entity.Identity.Info = value; }
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

        public IDomainEvent Apply(PersonCommand<CreatePerson> command)
        {
            PersonEvent<CreatePerson> domainEvent = new PersonEvent<CreatePerson>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<CreatePerson> domainEvent)
        {
            this.Id = domainEvent.PersonId;
            this.TenantId = domainEvent.TenantId;
            this.Name = domainEvent.Arguments.Name;
            this.Info = domainEvent.Arguments.Info;
            this.FirstName = domainEvent.Arguments.FirstName;
            this.StartDate = domainEvent.Arguments.StartDate;
            this.EndDate = domainEvent.Arguments.EndDate;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(PersonCommand<ChangePersonName> command)
        {
            PersonEvent<ChangePersonName> domainEvent = new PersonEvent<ChangePersonName>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<ChangePersonName> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;
            this.FirstName = domainEvent.Arguments.FirstName;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(PersonCommand<ChangePersonPeriod> command)
        {
            PersonEvent<ChangePersonPeriod> domainEvent = new PersonEvent<ChangePersonPeriod>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<ChangePersonPeriod> domainEvent)
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
