
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Entities
{
    public class DomainInfo
        : AuditableDataEntity<Guid>
    {
        public DomainInfo()
        : base() { }

        public DomainInfo(Guid id)
        : base(id) { }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual Domain Domain { get; set; }
    }
}
