
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands
{
    public abstract class TenantCommand<TIntent>
        : Command where TIntent : IIntent
    {
        public TenantCommand() { }

        public TenantCommand(TIntent intent)
            : this()
        {
            this.Intent = intent;
        }

        public Guid TenantId { get; set; }

        public TIntent Intent { get; set; }
    }
}
