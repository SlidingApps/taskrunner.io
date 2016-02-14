

using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class CreatePerson
        : Command
    {
        public CreatePerson()
            : base()
        { }

        public CreatePerson(Guid organizationId, string name, string firstName, string info, DateTime startDate, DateTime endDate)
            : this()
        {
            this.OrganizationId = organizationId;
            this.Name = name;
            this.Info = info;
            this.FirstName = firstName;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Guid OrganizationId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Info { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
