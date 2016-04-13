
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Queries
{
    public class TenantCodeQuery
        : IQuery<TenantCodeAvailability>
    {
        public TenantCodeQuery(string code)
        {
            this.Code = code;
        }

        public string Code { get; set; }
    }
}
