
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantDomainInfoMap
        : AuditableDataEntityMap<Entities.TenantDomainInfo, Guid>
    {
        private const string TABLE_NAME = "Tenant_Domain_Info_S";

        public TenantDomainInfoMap()
            : base(Metadata.SCHEMA_NAME, TenantDomainInfoMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Description);

            this.References(x => x.TenantDomain).Unique().Column("TenantDomainId");
        }
    }
}
