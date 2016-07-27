
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class TenantInfo
        : AuditableDataEntity<Guid>
    {
        public TenantInfo()
        : base() { }

        public TenantInfo(Guid id)
        : base(id) { }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual EntityStatus Status { get; set; }

        public virtual string Link { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
