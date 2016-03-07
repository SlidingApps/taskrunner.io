
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonPeriodChanged
        : DomainEvent
    {
        public PersonPeriodChanged(ChangePersonPeriod command)
            : base(command.Id)
        {
            this.PersonId = command.PersonId;
            this.TenantId = command.TenantId;
            this.StartDate = command.StartDate;
            this.EndDate = command.EndDate;
        }

        public Guid PersonId { get; set; }

        public Guid TenantId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
