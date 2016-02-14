
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Entities
{
    public class PersonIdentity
        : AuditableDataEntity<Guid>
    {
        public PersonIdentity()
        : base() { }

        public PersonIdentity(Guid id)

        : base(id) { }
        public virtual string Name { get; set; }

        public virtual string Info { get; set; }

        public virtual string FirstName { get; set; }

        public virtual Person Person { get; set; }
    }
}
