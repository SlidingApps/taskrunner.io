
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Entities
{
    public class MailCommunication
        : AuditableDataEntity<Guid>
    {
        public MailCommunication()
            : base() { }

        public MailCommunication(Guid id)
            : base(id) { }

        public virtual string ExternalId { get; set; }

        public virtual string Recipient { get; set; }

        public virtual string Subject { get; set; }

        public virtual string Content { get; set; }

        public virtual MailStatus Status { get; set; }

        public virtual Communication Communication { get; set; }

    }
}
