
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts
{
    public sealed class AccountEvent<TProps>
        : DomainEvent<TProps>, IDomainEvent
        where TProps : IIntent
    {
        public AccountEvent()
            : base() { }

        public AccountEvent(AccountCommand<TProps> command)
            : base(command)
        {
            this.AccountId = command.AccountId;
        }

        public Guid AccountId { get; set; }
    }
}
