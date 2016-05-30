﻿
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class TenantAccountMap
        : AuditableDataEntityMap<Entities.TenantAccount, Guid>
    {
        /// <summary>
        /// The <see cref="TenantAccount"/> database table name.
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
            this.HasOne(x => x.RoleSet).Cascade.All().PropertyRef(x => x.TenantAccount).LazyLoad(Laziness.Proxy);
        }
    }
}
