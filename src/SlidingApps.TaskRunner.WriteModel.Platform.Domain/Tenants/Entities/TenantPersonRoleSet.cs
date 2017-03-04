
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class TenantPersonRoleSet
        : AuditableDataEntity<Guid>
    {
        public TenantPersonRoleSet()
        : base() { }

        public TenantPersonRoleSet(Guid id)
        : base(id) { }

        public virtual bool IsOwner { get; set; }

        public virtual bool IsMember { get; set; }

        public virtual bool IsFollower { get; set; }

        public virtual TenantPerson TenantPerson { get; set; }
    }
}
