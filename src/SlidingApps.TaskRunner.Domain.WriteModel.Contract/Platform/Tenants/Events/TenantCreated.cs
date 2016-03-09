
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Events
{
    public class TenantCreated
         : TenantEvent<Intents.CreateTenant>
    {
        public TenantCreated(CreateTenant command)
            : base(command) { }
    }
}
