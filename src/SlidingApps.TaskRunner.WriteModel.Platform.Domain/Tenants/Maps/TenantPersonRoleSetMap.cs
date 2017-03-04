
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantPersonRoleSetMap
        : AuditableDataEntityMap<Entities.TenantPersonRoleSet, Guid>
    {
        /// <summary>
        /// The <see cref="TenantAccountRoleSet"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Tenant_Person_RoleSet_S";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TenantPersonRoleSetMap()
            : base(Metadata.SCHEMA_NAME, TenantPersonRoleSetMap.TABLE_NAME)
        {
            this.Map(x => x.IsOwner);
            this.Map(x => x.IsMember);
            this.Map(x => x.IsFollower);

            this.References(x => x.TenantPerson).Unique().Column("TenantPersonId");
        }
    }
}
