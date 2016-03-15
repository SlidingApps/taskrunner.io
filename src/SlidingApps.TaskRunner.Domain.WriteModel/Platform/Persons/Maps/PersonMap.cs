using SlidingApps.TaskRunner.Foundation.NHibernate;
using FluentNHibernate.Mapping;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Maps
{
    public class PersonMap
        : AuditableDataEntityMap<Entities.Account, Guid>
    {
        private const string TABLE_NAME = "Person_H";

        public PersonMap()
            : base(Metadata.SCHEMA_NAME, PersonMap.TABLE_NAME)
        {
            this.Map(x => x.TenantId);
            this.Map(x => x.StartDate);
            this.Map(x => x.EndDate);

            this.HasOne(x => x.Profile).Cascade.All().PropertyRef(x => x.Account).LazyLoad(Laziness.Proxy);
        }
    }
}
