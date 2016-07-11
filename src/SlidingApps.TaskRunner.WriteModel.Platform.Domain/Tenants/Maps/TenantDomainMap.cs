
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantDomainMap
        : AuditableDataEntityMap<Entities.TenantDomain, Guid>
    {
        /// <summary>
        /// The <see cref="TenantAccount"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Domain_L";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantDomainMap()
            : base(Metadata.SCHEMA_NAME, TenantAccountMap.TABLE_NAME)
        {
            this.References(x => x.Tenant).Unique().Column("TenantId");
            this.References(x => x.Domain).Unique().Column("DomainId");
        }
    }
}
