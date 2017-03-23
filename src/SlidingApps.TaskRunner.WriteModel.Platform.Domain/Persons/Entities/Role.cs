
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public abstract class Role
        : AuditableDataEntity<Guid>
    {
        public virtual Guid PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
