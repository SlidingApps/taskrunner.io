
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.ReadModel;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries
{
    public class OrganizationCollectionQuery
        : IQuery<OrganizationCollection>, IPagingFormatValues
    {
        public OrganizationCollectionQuery(string code = null, int page = 1, int pageSize = 10)
        {
            this.Code = code;
            this.Page = page;
            this.PageSize = pageSize;
        }

        public string Code { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
