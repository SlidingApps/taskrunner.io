
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class TenantAccount
        : DomainEntity<Guid, Entities.TenantAccount>
    {
        public TenantAccount()
            : base() { }

        public TenantAccount(Entities.TenantAccount entity)
            : this()
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
            this.role = new TenantAccountRoleSet(entity.RoleSet ?? new Entities.TenantAccountRoleSet(Guid.NewGuid()));
        }

        private TenantAccountRoleSet role;

        public Guid AccountId
        {
            get { return this.entity.AccountId; }
            private set { this.entity.AccountId = value; }
        }

        public TenantAccountRoleSet Role
        {
            get { return this.role; }
            private set { this.role = value; }
        }
    }
}
