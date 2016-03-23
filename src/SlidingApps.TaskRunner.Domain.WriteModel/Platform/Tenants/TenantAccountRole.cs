
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class TenantAccountRole
        : DomainEntity<Guid, Entities.TenantAccountRole>
    {
        public TenantAccountRole()
            : base() { }

        public TenantAccountRole(Entities.TenantAccountRole entity)
            : this()
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
        }
    }
}
