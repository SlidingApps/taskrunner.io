
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries
{
    public class PersonQuery
        : IQuery<Person>
    {
        public PersonQuery(Guid organizationId, Guid personId)
        {
            this.OrganizationId = organizationId;
            this.PersonId = personId;
        }

        public Guid OrganizationId { get; set; }

        public Guid PersonId { get; set; }
    }
}
