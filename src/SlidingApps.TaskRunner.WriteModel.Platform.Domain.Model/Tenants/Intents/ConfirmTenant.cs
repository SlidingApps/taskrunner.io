
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents
{
    public class ConfirmTenant
        : IIntent
    {
        public ConfirmTenant()
        : base() { }

        public ConfirmTenant(string code, string link)
            : this()
        {
            this.Code = code;
            this.Link = link;
        }

        public string Code { get; set; }

        public string Link { get; set; }
    }
}
