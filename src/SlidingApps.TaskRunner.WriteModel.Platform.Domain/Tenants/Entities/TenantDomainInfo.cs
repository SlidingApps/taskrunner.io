
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class TenantDomainInfo
        : AuditableDataEntity<Guid>
    {
        public TenantDomainInfo()
            : base() { }

        public TenantDomainInfo(Guid id)
            : base(id) { }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual TenantDomain TenantDomain { get; set; }
    }
}
