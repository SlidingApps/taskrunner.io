
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Maps
{
    public class PersonIdentityMap
        : AuditableDataEntityMap<Entities.AccountProfile, Guid>
    {
        private const string TABLE_NAME = "Person_Identity_S";

        public PersonIdentityMap()
            : base(Metadata.SCHEMA_NAME, PersonIdentityMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.FirstName);
            this.Map(x => x.Info);

            this.References(x => x.Account).Unique().Column("AccountId");
        }
    }
}
