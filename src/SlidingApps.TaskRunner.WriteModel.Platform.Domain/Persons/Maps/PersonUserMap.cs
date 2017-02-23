
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Maps
{
    public class PersonUserMap
        : AuditableDataEntityMap<Entities.PersonUser, Guid>
    {
        private const string TABLE_NAME = "Person_User_S";

        public PersonUserMap()
            : base(Metadata.SCHEMA_NAME, PersonUserMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Password);
            this.Map(x => x.Salt);
            this.Map(x => x.ValidUntil);

            this.References(x => x.Account).Unique().Column("PersonId");
        }
    }
}
