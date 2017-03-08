
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries
{
    public class PersonCollectionQuery
        : IQuery<PersonCollection>, IPagingFormatValues
    {
        public PersonCollectionQuery(string name, int page = 1, int pageSize = 10)
        {
            this.Name = name;
            this.Page = page;
            this.PageSize = pageSize;
        }

        public string Name { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
