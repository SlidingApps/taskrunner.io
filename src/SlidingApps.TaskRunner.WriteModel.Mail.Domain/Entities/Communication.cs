
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Entities
{
    public class Communication
        : AuditableDataEntity<Guid>
    {
        public Communication()
            : base() { }

        public virtual MailCommunication Mail { get; set; }
    }
}
