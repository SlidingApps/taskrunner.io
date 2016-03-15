
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Entities
{
    class User
        : AuditableDataEntity<Guid>
    {
        public virtual Guid PersonId { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }
    }
}
