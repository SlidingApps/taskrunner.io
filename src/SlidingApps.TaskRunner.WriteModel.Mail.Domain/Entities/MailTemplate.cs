
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Entities
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
