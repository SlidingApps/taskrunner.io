
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries
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
