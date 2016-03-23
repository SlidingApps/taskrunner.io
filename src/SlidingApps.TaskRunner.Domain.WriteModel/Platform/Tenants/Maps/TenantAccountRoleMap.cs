
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Maps
{
    public class TenantAccountRoleMap
        : AuditableDataEntityMap<Entities.TenantAccountRole, Guid>
    {
        /// <summary>
        /// The <see cref="TenantAccountRole"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Account_Role_S";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantAccountRoleMap()
            : base(Metadata.SCHEMA_NAME, TenantAccountMap.TABLE_NAME)
        {
            this.Map(x => x.IsOwner);
            this.Map(x => x.IsAdmin);
            this.Map(x => x.IsMember);
            this.Map(x => x.IsFollower);
            this.Map(x => x.ValidFrom);

            this.References(x => x.TenantAccount).Unique().Column("TenantAccountId");
        }
    }
}
