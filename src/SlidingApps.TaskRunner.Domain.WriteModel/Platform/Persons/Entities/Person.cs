
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Entities
{
    public class Person
        : AuditableDataEntity<Guid>
    {
        public virtual Guid TenantId { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual PersonIdentity Identity { get; set; }
    }
}
