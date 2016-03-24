
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class TenantAccountRoleSet
        : DomainEntity<Guid, Entities.TenantAccountRoleSet>
    {
        public TenantAccountRoleSet()
            : base() { }

        public TenantAccountRoleSet(Entities.TenantAccountRoleSet entity)
            : this()
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
        }

        public virtual bool IsOwner
        {
            get { return this.entity.IsOwner; }
            private set { this.entity.IsOwner = value; }
        }

        public virtual bool IsAdmin
        {
            get { return this.entity.IsAdmin; }
            private set { this.entity.IsAdmin = value; }
        }

        public virtual bool IsMember
        {
            get { return this.entity.IsMember; }
            private set { this.entity.IsMember = value; }
        }

        public virtual bool IsFollower
        {
            get { return this.entity.IsFollower; }
            private set { this.entity.IsFollower = value; }
        }
    }
}
