
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Entities
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

        public virtual MailTemplate MailTemplate { get; set; }
    }
}
