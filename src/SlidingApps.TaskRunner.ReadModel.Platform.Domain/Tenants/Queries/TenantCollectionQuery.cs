
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries
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
