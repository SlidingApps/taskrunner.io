
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Entities
{
    public class MailCommunication
        : AuditableDataEntity<Guid>
    {
        public MailCommunication()
            : base() { }

        public virtual string ExternalId { get; set; }

        public virtual string Recipient { get; set; }

        public virtual string Content { get; set; }

        public virtual MailStatus Status { get; set; }

        public virtual Communication Communication { get; set; }
    }
}
