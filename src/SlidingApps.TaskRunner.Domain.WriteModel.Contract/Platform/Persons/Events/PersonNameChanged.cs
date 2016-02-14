
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonNameChanged
        : DomainEvent
    {
        public PersonNameChanged(ChangePersonName command)
            : base(command.Id)
        {
            this.PersonId = command.PersonId;
            this.OrganizationId = command.OrganizationId;
            this.Name = command.Name;
            this.FirstName = command.FirstName;
        }

        public Guid PersonId { get; set; }

        public Guid OrganizationId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
