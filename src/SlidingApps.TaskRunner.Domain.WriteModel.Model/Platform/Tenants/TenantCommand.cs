
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class TenantCommand<TIntent>
        : Command<TIntent> where TIntent : IIntent
    {
        public TenantCommand()
            :base() { }

        public TenantCommand(TIntent intent)
            : this()
        {
            this.Intent = intent;
        }

        public TenantCommand(Guid tenantId, TIntent intent)
            : this(intent)
        {
            this.TenantId = tenantId;
        }

        public Guid TenantId { get; set; }
    }
}
