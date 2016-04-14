
using SlidingApps.TaskRunner.Foundation.ReadModel;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations
{
    public class TenantCodeAvailability
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants/{code}/availability";

        private TenantCodeAvailability()
        {
            this.templates.Add(new SelfLinkTemplate(TenantCodeAvailability.SELF_LINK_TEMPLATE));
        }

        public TenantCodeAvailability(string code, bool isAvailable)
            : this()
        {
            this.Code = code;
            this.IsAvailable = isAvailable;
        }

        public string Code { get; set; }

        public bool IsAvailable { get; set; }
    }
}
