
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants
{
    public sealed class TenantEvent<TIntent>
        : DomainEvent<TIntent> where TIntent : IIntent
    {
        public TenantEvent()
            : base() { }

        public TenantEvent(TenantCommand<TIntent> command)
            : base(command)
        {
            this.TenantId = command.TenantId;
        }

        public Guid TenantId { get; set; }
    }
}
