
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Maps
{
    public class PersonIdentityMap
        : AuditableDataEntityMap<Entities.PersonIdentity, Guid>
    {
        private const string TABLE_NAME = "Account_Profile_S";

        public PersonIdentityMap()
            : base(Metadata.SCHEMA_NAME, PersonIdentityMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.FirstName);
            this.Map(x => x.Info);
            this.Map(x => x.CreationTime);
            this.Map(x => x.Status).CustomType<GenericEnumMapper<EntityStatus>>();
            this.Map(x => x.Link);

            this.References(x => x.Account).Unique().Column("AccountId");
        }
    }
}
