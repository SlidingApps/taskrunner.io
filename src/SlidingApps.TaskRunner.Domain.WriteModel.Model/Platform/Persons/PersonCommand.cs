
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class PersonCommand<TIntent>
        : TenantCommand<TIntent> where TIntent : IIntent
    {
        public PersonCommand()
            :base() { }

        public PersonCommand(Guid tenantId, TIntent intent)
            : base(tenantId, intent)
        {
            this.TenantId = tenantId;
        }

        public PersonCommand(Guid tenantId, Guid personId, TIntent intent)
            : this(tenantId, intent)
        {
            this.PersonId = personId;
        }

        public Guid PersonId { get; set; }
    }
}
