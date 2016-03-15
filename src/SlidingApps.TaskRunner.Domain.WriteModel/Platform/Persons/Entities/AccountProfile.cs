
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Entities
{
    public class AccountProfile
        : AuditableDataEntity<Guid>
    {
        public AccountProfile()
            : base() { }

        public AccountProfile(Guid id)

        : base(id) { }
        public virtual string Name { get; set; }

        public virtual string Info { get; set; }

        public virtual string FirstName { get; set; }

        public virtual Account Account { get; set; }
    }
}
