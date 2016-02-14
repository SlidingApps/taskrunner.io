
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using FluentValidation;
using FluentValidation.Results;
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

        public Guid OrganizationId
        {
            get { return this.entity.OrganizationId; }
            private set { this.entity.OrganizationId = value; }
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

        public IDomainEvent Apply(CreatePerson command)
        {
            PersonCreated domainEvent = new PersonCreated(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonCreated domainEvent)
        {
            this.Id = domainEvent.PersonId;
            this.OrganizationId = domainEvent.OrganizationId;
            this.Name = domainEvent.Name;
            this.Info = domainEvent.Info;
            this.FirstName = domainEvent.FirstName;
            this.StartDate = domainEvent.StartDate;
            this.EndDate = domainEvent.EndDate;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(ChangePersonName command)
        {
            PersonNameChanged domainEvent = new PersonNameChanged(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonNameChanged domainEvent)
        {
            this.Name = domainEvent.Name;
            this.FirstName = domainEvent.FirstName;

            this.DomainEvents.Add(domainEvent);
        }

        public IDomainEvent Apply(ChangePersonPeriod command)
        {
            PersonPeriodChanged domainEvent = new PersonPeriodChanged(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonPeriodChanged domainEvent)
        {
            this.StartDate = domainEvent.StartDate;
            this.EndDate = domainEvent.EndDate;

            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
