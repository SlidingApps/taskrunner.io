
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants
{
    public class TenantPerson
        : DomainEntity<Guid, Entities.TenantPerson>
    {
        public TenantPerson()
            : base() { }

        public TenantPerson(Entities.TenantPerson entity)
            : this()
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;

            if (this.entity.RoleSet == null)
            {
                this.entity.RoleSet = new Entities.TenantPersonRoleSet(Guid.NewGuid());
                this.entity.RoleSet.TenantPerson = this.entity;
            };
        }

        public Guid AccountId
        {
            get { return this.entity.PersonId; }
            private set { this.entity.PersonId = value; }
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
