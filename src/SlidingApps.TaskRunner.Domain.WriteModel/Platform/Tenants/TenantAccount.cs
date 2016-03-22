
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

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
        }

        public Guid AccountId
        {
            get { return this.entity.AccountId; }
            private set { this.entity.AccountId = value; }
        }
    }
}
