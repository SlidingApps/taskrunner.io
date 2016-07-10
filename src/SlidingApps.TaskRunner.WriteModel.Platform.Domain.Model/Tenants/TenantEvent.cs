
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants
{
    public sealed class TenantEvent<TIntent>
        : DomainEvent<TenantKey, TIntent> where TIntent : IIntent
    {
        public TenantEvent()
            : base() { }

        public TenantEvent(TenantCommand<TIntent> command)
            : base(command) { }
    }
}
