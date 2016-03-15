
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts
{
    public class AccountCommand<TIntent>
        : TenantCommand<TIntent> where TIntent : IIntent
    {
        public AccountCommand()
            :base() { }

        public AccountCommand(Guid tenantId, TIntent intent)
            : base(tenantId, intent)
        {
            this.TenantId = tenantId;
        }

        public AccountCommand(Guid tenantId, Guid accountId, TIntent intent)
            : this(tenantId, intent)
        {
            this.AccountId = accountId;
        }

        public Guid AccountId { get; set; }
    }
}
