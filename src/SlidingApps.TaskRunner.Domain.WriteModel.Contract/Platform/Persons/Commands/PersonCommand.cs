
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public abstract class PersonCommand<TIntent>
        : Command where TIntent : IIntent
    {
        public PersonCommand() { }

        public PersonCommand(Guid tenantId, TIntent intent)
            : this()
        {
            this.TenantId = tenantId;
            this.Intent = intent;
        }

        public PersonCommand(Guid tenantId, Guid personId, TIntent intent)
            : this()
        {
            this.TenantId = tenantId;
            this.PersonId = personId;
            this.Intent = intent;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }

        public TIntent Intent { get; set; }
    }
}
