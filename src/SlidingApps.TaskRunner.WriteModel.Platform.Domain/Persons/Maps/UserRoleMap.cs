
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Maps
{
    public class UserRoleMap
        : AuditableDataEntitySubMap<Entities.UserRole, Guid>
    {
        private const string TABLE_NAME = "Person_Role_User_S";

        public UserRoleMap()
            : base(Metadata.SCHEMA_NAME, UserRoleMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Password);
            this.Map(x => x.Salt);
            this.Map(x => x.ValidUntil);

            this.References(x => x.Person).Unique().Column("PersonId");
        }
    }
}
