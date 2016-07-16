
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants
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

            if (this.entity.RoleSet == null)
            {
                this.entity.RoleSet = new Entities.TenantAccountRoleSet(Guid.NewGuid());
                this.entity.RoleSet.TenantAccount = this.entity;
            };
        }

        public Guid AccountId
        {
            get { return this.entity.AccountId; }
            private set { this.entity.AccountId = value; }
        }

        public virtual bool IsOwner
        {
            get { return this.entity.RoleSet.IsOwner; }
            private set { this.entity.RoleSet.IsOwner = value; }
        }

        public virtual bool IsMember
        {
            get { return this.entity.RoleSet.IsMember; }
            private set { this.entity.RoleSet.IsMember = value; }
        }

        public virtual bool IsFollower
        {
            get { return this.entity.RoleSet.IsFollower; }
            private set { this.entity.RoleSet.IsFollower = value; }
        }

        public TenantEvent<SetTenantOwner> Apply(TenantCommand<SetTenantOwner> command)
        {
            TenantEvent<SetTenantOwner> domainEvent = new TenantEvent<SetTenantOwner>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantEvent<SetTenantOwner> domainEvent)
        {
            this.IsOwner = true;

            this.DomainEvents.Add(domainEvent);
        }
    }
}
