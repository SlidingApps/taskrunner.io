
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class TenantDomain
        : AuditableDataEntity<Guid>
    {
        public TenantDomain()
            : base() { }

        public TenantDomain(Guid id)
            : base(id) { }

        public virtual Tenant Tenant { get; set; }

        public virtual Domain Domain { get; set; }
    }
}
