
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts
{
    public sealed class AccountEvent<TProps>
        : DomainEvent<TProps> where TProps : IIntent
    {
        public AccountEvent()
            : base() { }

        public AccountEvent(AccountCommand<TProps> command)
            : base(command)
        {
            this.TenantId = command.TenantId;
            this.AccountId = command.AccountId;
        }

        public Guid TenantId { get; set; }

        public Guid AccountId { get; set; }
    }
}
