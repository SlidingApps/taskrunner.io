
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public class PersonIdentity
        : AuditableDataEntity<Guid>
    {
        public PersonIdentity()
            : base() { }

        public PersonIdentity(Guid id)
            : base(id) { }

        public virtual string Name { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string Info { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual EntityStatus Status { get; set; }

        public virtual string Link { get; set; }

        public virtual Person Account { get; set; }
    }
}
