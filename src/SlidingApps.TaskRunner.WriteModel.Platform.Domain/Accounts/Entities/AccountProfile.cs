
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Accounts.Entities
{
    public class AccountProfile
        : AuditableDataEntity<Guid>
    {
        public AccountProfile()
            : base() { }

        public AccountProfile(Guid id)
            : base(id) { }

        public virtual string Name { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string Info { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual EntityStatus Status { get; set; }

        public virtual string Link { get; set; }

        public virtual Account Account { get; set; }
    }
}
