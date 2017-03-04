
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantPersonMap
        : AuditableDataEntityMap<Entities.TenantPerson, Guid>
    {
        /// <summary>
        /// The <see cref="TenantPerson"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Person_L";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantPersonMap()
            : base(Metadata.SCHEMA_NAME, TenantPersonMap.TABLE_NAME)
        {
            this.Map(x => x.PersonId);

            this.References(x => x.Tenant).Unique().Column("TenantId");
            this.HasOne(x => x.RoleSet).Cascade.All().PropertyRef(x => x.TenantPerson).LazyLoad(Laziness.Proxy);
        }
    }
}
