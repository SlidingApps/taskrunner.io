
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications;
using System;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Maps
{
    public class MailCommunicationMap
        : AuditableDataEntityMap<MailCommunication, Guid>
    {
        private const string TABLE_NAME = "Communication_Mail_S";

        public MailCommunicationMap()
            : base(Metadata.SCHEMA_NAME, MailCommunicationMap.TABLE_NAME)
        {
            this.Map(x => x.ExternalId);
            this.Map(x => x.Recipient);
            this.Map(x => x.Subject);
            this.Map(x => x.TextContent);
            this.Map(x => x.HtmlContent);
            this.Map(x => x.Status).CustomType<GenericEnumMapper<MailStatus>>();

            this.References(x => x.Communication).Unique().Column("CommunicationId");
        }
    }
}
