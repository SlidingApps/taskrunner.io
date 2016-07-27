
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents
{
    public class ConfirmTenant
        : IIntent
    {
        public ConfirmTenant()
        : base() { }

        public ConfirmTenant(string link)
            : this()
        {
            this.Link = link;
        }

        public string Link { get; set; }
    }
}
