
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries
{
    public class PersonQuery
        : IQuery<Person>
    {
        public PersonQuery(Guid tenantId, Guid personId)
        {
            this.TenantId = tenantId;
            this.PersonId = personId;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }
    }
}
