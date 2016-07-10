
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants
{
    public class TenantKey
        : IBusinessKey
    {
        public TenantKey(string code)
        {
            this.Code = code;
        }

        public string Code { get; set; }

        public static TenantKey Empty
        {
            get { return new TenantKey(string.Empty); }
        }
    }
}
