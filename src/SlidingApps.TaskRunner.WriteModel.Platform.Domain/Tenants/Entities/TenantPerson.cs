
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class TenantPerson
        : AuditableDataEntity<Guid>
    {
        public TenantPerson()
            : base() { }

        public TenantPerson(Guid id)
            : base(id) { }

        public virtual Tenant Tenant { get; set; }

        public virtual Guid PersonId { get; set; }

        public virtual TenantPersonRoleSet RoleSet { get; set; }
    }
}
