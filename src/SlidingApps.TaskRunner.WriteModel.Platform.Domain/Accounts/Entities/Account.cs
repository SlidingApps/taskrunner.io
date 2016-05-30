
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Accounts.Entities
{
    public class Account
        : AuditableDataEntity<Guid>
    {
        public virtual string EmailAddress { get; set; }

        public virtual AccountProfile Profile { get; set; }

        public virtual AccountUser User { get; set; }
    }
}
