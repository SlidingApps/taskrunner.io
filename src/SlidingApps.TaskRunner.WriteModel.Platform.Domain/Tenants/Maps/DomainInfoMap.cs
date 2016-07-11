
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class DomainInfoMap
        : AuditableDataEntityMap<Entities.DomainInfo, Guid>
    {
        private const string TABLE_NAME = "Domain_Info_S";

        public DomainInfoMap()
            : base(Metadata.SCHEMA_NAME, DomainInfoMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Description);
            this.Map(x => x.ValidFrom);
            this.Map(x => x.ValidUntil);

            this.References(x => x.Domain).Unique().Column("DomainId");
        }
    }
}
