
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class Tenant
        : AuditableDataEntity<Guid>
    {
        public Tenant()
            : base()
        {
            this.Accounts = new List<TenantAccount>();
        }

        public virtual string Code { get; set; }

        public virtual TenantInfo Info { get; set; }

        public virtual IList<TenantAccount> Accounts { get; set; }
    }
}
