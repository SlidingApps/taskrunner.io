
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants
{
    public class TenantCommand<TIntent>
        : Command<TenantKey, TIntent> where TIntent : IIntent
    {
        public TenantCommand()
            :base() { }

        public TenantCommand(TIntent intent)
            : base(TenantKey.Empty, intent) { }

        public TenantCommand(string code, TIntent intent)
            : base(new TenantKey(code), intent) { }

        public TenantCommand(TenantKey key, TIntent intent)
            : base(key, intent) { }
    }
}
