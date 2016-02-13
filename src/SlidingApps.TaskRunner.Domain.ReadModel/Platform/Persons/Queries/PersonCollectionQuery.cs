
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries
{
    public class PersonCollectionQuery
        : IQuery<PersonCollection>, IPagingFormatValues
    {
        public PersonCollectionQuery(Guid organizationId, string name, int page = 1, int pageSize = 10)
        {
            this.OrganizationId = organizationId;
            this.Name = name;
            this.Page = page;
            this.PageSize = pageSize;
        }

        public Guid OrganizationId { get; set; }

        public string Name { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
