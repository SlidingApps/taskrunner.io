
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonCreated
        : DomainEvent
    {
        public PersonCreated(CreatePerson command)
            : base(command.Id)
        {
            this.PersonId = Guid.NewGuid();
            this.OrganizationId = command.OrganizationId;
            this.Name = command.Name;
            this.FirstName = command.FirstName;
            this.Info = command.Info;
            this.StartDate = command.StartDate;
            this.EndDate = command.EndDate;
        }

        public Guid PersonId { get; set; }

        public Guid OrganizationId { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public string FirstName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
