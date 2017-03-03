
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities
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

        public virtual string TextContent { get; set; }

        public virtual string HtmlContent { get; set; }

        public virtual MailStatus Status { get; set; }

        public virtual Infrastructure.Domain.Communications.Entities.Communication Communication { get; set; }

    }
}
