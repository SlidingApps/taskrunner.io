
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class ChangePersonName
        : Command
    {
        public ChangePersonName()
            : base()
        { }

        public ChangePersonName(Guid organizationId, Guid personId, string name, string firstName)
            : this()
        {
            this.OrganizationId = organizationId;
            this.PersonId = personId;
            this.Name = name;
            this.FirstName = firstName;
        }

        public Guid OrganizationId { get; set; }

        public Guid PersonId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
