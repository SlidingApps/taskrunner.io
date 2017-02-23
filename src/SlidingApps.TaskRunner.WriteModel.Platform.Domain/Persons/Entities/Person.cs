
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public class Person
        : AuditableDataEntity<Guid>
    {
        public virtual string EmailAddress { get; set; }

        public virtual PersonIdentity Profile { get; set; }

        public virtual PersonUser User { get; set; }
    }
}
