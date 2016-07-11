
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class Domain
        : AuditableDataEntity<Guid>
    {
        public Domain()
            : base() { }

        public virtual string Code { get; set; }

        public virtual DomainInfo Info { get; set; }
    }
}
