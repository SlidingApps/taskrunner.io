
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Maps
{
    public class MailCommunicationMap
        : AuditableDataEntityMap<Entities.MailCommunication, Guid>
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
