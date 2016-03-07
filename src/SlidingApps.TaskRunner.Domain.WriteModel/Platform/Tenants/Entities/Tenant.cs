
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Entities
{
    public class Tenant
        : AuditableDataEntity<Guid>
    {
        public virtual string Code { get; set; }

        public virtual TenantInfo Info { get; set; }
    }
}
