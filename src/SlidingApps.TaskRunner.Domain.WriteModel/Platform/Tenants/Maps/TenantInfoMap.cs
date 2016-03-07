
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Maps
{
    public class OrganizationInfoMap
        : AuditableDataEntityMap<Entities.TenantInfo, Guid>
    {
        private const string TABLE_NAME = "Tenant_S";

        public OrganizationInfoMap()
            : base(Metadata.SCHEMA_NAME, OrganizationInfoMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Description);
            this.Map(x => x.ValidFrom);
            this.Map(x => x.ValidUntil);

            this.References(x => x.Tenant).Unique().Column("TenantId");
        }
    }
}
