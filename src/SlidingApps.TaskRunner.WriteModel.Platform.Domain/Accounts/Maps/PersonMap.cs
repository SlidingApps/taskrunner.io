using SlidingApps.TaskRunner.Foundation.NHibernate;
using FluentNHibernate.Mapping;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Maps
{
    public class PersonMap
        : AuditableDataEntityMap<Entities.Person, Guid>
    {
        private const string TABLE_NAME = "Account_H";

        public PersonMap()
            : base(Metadata.SCHEMA_NAME, PersonMap.TABLE_NAME)
        {
            this.Map(x => x.EmailAddress);

            this.HasOne(x => x.Profile).Cascade.All().PropertyRef(x => x.Account).LazyLoad(Laziness.Proxy);
            this.HasOne(x => x.User).Cascade.All().PropertyRef(x => x.Account).LazyLoad(Laziness.Proxy);
        }
    }
}
