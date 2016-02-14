
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class ChangePersonPeriod
        : Command
    {
        public ChangePersonPeriod()
            : base()
        { }

        public ChangePersonPeriod(Guid organizationId, Guid personId, DateTime startDate, DateTime endDate)
            : this()
        {
            this.OrganizationId = organizationId;
            this.PersonId = personId;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Guid OrganizationId { get; set; }

        public Guid PersonId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}