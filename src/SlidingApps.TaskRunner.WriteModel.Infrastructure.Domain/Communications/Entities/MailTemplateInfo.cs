
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities
{
    public class MailTemplateInfo
        : AuditableDataEntity<Guid>
    {
        public MailTemplateInfo()
            : base() { }

        public MailTemplateInfo(Guid id)
            : base(id) { }

        public virtual string Subject { get; set; }

        public virtual string TextTemplate { get; set; }

        public virtual string HtmlTemplate { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual Infrastructure.Domain.Communications.Entities.MailTemplate MailTemplate { get; set; }
    }
}
