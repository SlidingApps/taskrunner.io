
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Maps
{
    public class TenantAccountMap
        : AuditableDataEntityMap<Entities.TenantAccount, Guid>
    {
        /// <summary>
        /// The <see cref="Tenant"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Account_L";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantAccountMap()
            : base(Metadata.SCHEMA_NAME, TenantAccountMap.TABLE_NAME)
        {
            this.Map(x => x.AccountId);

            this.References(x => x.Tenant).Unique().Column("TenantId");
        }
    }
}
