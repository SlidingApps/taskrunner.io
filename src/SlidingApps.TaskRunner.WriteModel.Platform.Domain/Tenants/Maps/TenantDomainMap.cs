
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
        public const string TABLE_NAME = "Tenant_Domain_S";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantDomainMap()
            : base(Metadata.SCHEMA_NAME, TenantDomainMap.TABLE_NAME)
        {
            this.Map(x => x.Code);

            this.References(x => x.Tenant).Unique().Column("TenantId");
            this.HasOne(x => x.Info).Cascade.All().PropertyRef(x => x.TenantDomain).LazyLoad(Laziness.Proxy);
        }
    }
}
