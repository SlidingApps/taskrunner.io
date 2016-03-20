
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Entities
{
    public class TenantAccount
        : AuditableDataEntity<Guid>
    {
        public TenantAccount()
            : base() { }

        public TenantAccount(Guid id)
            : base(id) { }

        public virtual Tenant Tenant { get; set; }

        public virtual Guid AccountId { get; set; }
    }
}
