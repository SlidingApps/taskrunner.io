
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities
{
    public class MailTemplate
        : AuditableDataEntity<Guid>
    {
        public MailTemplate()
            : base() { }

        public virtual string Code { get; set; }

        public virtual MailTemplateInfo Info { get; set; }
    }
}
