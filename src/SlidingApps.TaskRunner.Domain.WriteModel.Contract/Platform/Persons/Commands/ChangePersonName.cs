
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

        public ChangePersonName(Guid tenantId, Guid personId, string name, string firstName)
            : this()
        {
            this.TenantId = tenantId;
            this.PersonId = personId;
            this.Name = name;
            this.FirstName = firstName;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
