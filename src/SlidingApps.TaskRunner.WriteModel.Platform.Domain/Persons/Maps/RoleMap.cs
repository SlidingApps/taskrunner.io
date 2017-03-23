
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Maps
{
    public class RoleMap
        : ClassMap<Role>
    {
        private const string TABLE_NAME = "Person_Role_S";

        public RoleMap()
        {
            this.Schema(Metadata.SCHEMA_NAME);
            this.Table(RoleMap.TABLE_NAME);

            this.Id(x => x.Id).GeneratedBy.Assigned();
            this.Polymorphism.Implicit();
        }
    }
}
