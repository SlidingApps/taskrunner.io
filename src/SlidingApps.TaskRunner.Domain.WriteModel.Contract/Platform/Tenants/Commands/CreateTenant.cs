

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands
{
    public class CreateTenant
        : TenantCommand<Intents.CreateTenant>
    {
        public CreateTenant()
            : base() { }

        public CreateTenant(Intents.CreateTenant intent)
            : this()
        {
            this.Intent = intent;
        }
    }
}
