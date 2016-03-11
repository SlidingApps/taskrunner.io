
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands
{
    public sealed class TenantCommand<TIntent>
        : Command<TIntent> where TIntent : IIntent
    {
        public TenantCommand()
            :base() { }

        public TenantCommand(TIntent intent)
            : this()
        {
            this.Intent = intent;
        }

        public Guid TenantId { get; set; }
    }
}
