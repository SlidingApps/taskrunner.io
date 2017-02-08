
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Maps
{
    public class CommunicationMap
        : AuditableDataEntityMap<Entities.Communication, Guid>
    {
        private const string TABLE_NAME = "Communication_H";

        public CommunicationMap()
            : base(Metadata.SCHEMA_NAME, CommunicationMap.TABLE_NAME)
        {
            this.HasOne(x => x.Mail).Cascade.All().PropertyRef(x => x.Communication).LazyLoad(Laziness.Proxy);
        }
    }
}
