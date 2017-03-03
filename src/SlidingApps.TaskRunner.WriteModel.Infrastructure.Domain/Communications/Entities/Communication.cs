
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities
{
    public class Communication
        : AuditableDataEntity<Guid>
    {
        public Communication()
            : base() { }

        public virtual MailCommunication Mail { get; set; }
    }
}
