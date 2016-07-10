
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts
{
    public sealed class AccountEvent<TProps>
        : DomainEvent<AccountKey, TProps>, IDomainEvent
        where TProps : IIntent
    {
        public AccountEvent()
            : base() { }

        public AccountEvent(AccountCommand<TProps> command)
            : base(command) { }
    }
}
