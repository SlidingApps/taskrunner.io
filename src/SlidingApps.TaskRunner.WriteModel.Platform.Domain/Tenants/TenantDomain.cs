
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants
{
    public class TenantDomain
        : DomainEntity<Guid, Entities.TenantDomain>
    {
        public TenantDomain()
            : base()
        {
            this.entity = new Entities.TenantDomain();

            this.Id = Guid.NewGuid();

            if (this.entity.Info == null)
            {
                this.entity.Info = new Entities.TenantDomainInfo(Guid.NewGuid());
                this.entity.Info.TenantDomain = this.entity;
            };
        }

        public TenantDomain(Entities.TenantDomain entity)
            : this()
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;

            if (this.entity.Info == null)
            {
                this.entity.Info = new Entities.TenantDomainInfo(Guid.NewGuid());
                this.entity.Info.TenantDomain = this.entity;
            };
        }

        public string Code
        {
            get { return this.entity.Code; }
            set { this.entity.Code = value; }
        }

        public string Name
        {
            get { return this.entity.Info.Name; }
            set { this.entity.Info.Name = value; }
        }

        public string Description
        {
            get { return this.entity.Info.Description; }
            set { this.entity.Info.Description = value; }
        }

        public void SetTenant(Entities.Tenant tenant)
        {
            this.entity.Tenant = tenant;
        }
    }
}
