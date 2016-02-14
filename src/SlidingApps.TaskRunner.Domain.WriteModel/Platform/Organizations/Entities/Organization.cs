
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Entities
{
    public class Organization
        : AuditableDataEntity<Guid>
    {
        public virtual string Code { get; set; }

        public virtual OrganizationInfo Info { get; set; }
    }
}
