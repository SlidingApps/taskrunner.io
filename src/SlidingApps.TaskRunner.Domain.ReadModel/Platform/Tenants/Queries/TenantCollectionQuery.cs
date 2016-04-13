
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.ReadModel;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Queries
{
    public class TenantCollectionQuery
        : IQuery<TenantCollection>, IPagingFormatValues
    {
        public TenantCollectionQuery(string code = null, int page = 1, int pageSize = 10)
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
