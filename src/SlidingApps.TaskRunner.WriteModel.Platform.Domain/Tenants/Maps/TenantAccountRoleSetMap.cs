
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantAccountRoleSetMap
        : AuditableDataEntityMap<Entities.TenantAccountRoleSet, Guid>
    {
        /// <summary>
        /// The <see cref="TenantAccountRoleSet"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Account_RoleSet_S";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantAccountRoleSetMap()
            : base(Metadata.SCHEMA_NAME, TenantAccountRoleSetMap.TABLE_NAME)
        {
            this.Map(x => x.IsOwner);
            this.Map(x => x.IsMember);
            this.Map(x => x.IsFollower);

            this.References(x => x.TenantAccount).Unique().Column("TenantAccountId");
        }
    }
}
