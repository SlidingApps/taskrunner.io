
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Entities
{
    public class OrganizationInfo
        : AuditableDataEntity<Guid>
    {
        public OrganizationInfo()
        : base() { }

        public OrganizationInfo(Guid id)
        : base(id) { }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
