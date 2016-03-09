
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Events
{
    public abstract class TenantEvent<TProps>
        : DomainEvent where TProps : IIntent
    {
        public TenantEvent()
            : base() { }

        protected TenantEvent(Guid correlationId)
            : base(correlationId) { }

        public TenantEvent(Commands.TenantCommand<TProps> command)
            : this(command.Id)
        {
            this.TenantId = command.TenantId;
            this.Props = command.Intent;
        }

        public Guid TenantId { get; set; }

        public TProps Props { get; set; }
    }
}
