
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Entities
{
    public class AccountUser
           : AuditableDataEntity<Guid>
    {
        public virtual Guid AccountId { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }
    }
}
