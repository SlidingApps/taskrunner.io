
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
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

        public virtual TenantAccountRoleSet RoleSet { get; set; }
    }
}
