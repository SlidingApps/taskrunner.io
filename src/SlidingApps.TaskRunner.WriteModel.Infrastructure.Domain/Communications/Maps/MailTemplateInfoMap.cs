
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Maps
{
    public class MailTemplateInfoMap
        : AuditableDataEntityMap<MailTemplateInfo, Guid>
    {
        private const string TABLE_NAME = "Mail_Template_Info_S";

        public MailTemplateInfoMap()
            : base(Metadata.SCHEMA_NAME, MailTemplateInfoMap.TABLE_NAME)
        {
            this.Map(x => x.Subject);
            this.Map(x => x.TextTemplate);
            this.Map(x => x.HtmlTemplate);
            this.Map(x => x.ValidFrom);
            this.Map(x => x.ValidUntil);

            this.References(x => x.MailTemplate).Unique().Column("MailTemplateId");
        }
    }
}
