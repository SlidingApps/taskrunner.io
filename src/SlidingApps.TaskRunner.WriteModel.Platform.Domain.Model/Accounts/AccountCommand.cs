
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts
{
    public class AccountCommand<TIntent>
        : Command<AccountKey, TIntent> where TIntent : IIntent
    {
        public AccountCommand()
            : base() { }

        public AccountCommand(TIntent intent)
            : base(AccountKey.Empty, intent) { }

        public AccountCommand(string name, TIntent intent)
            : base(new AccountKey(name), intent) { }

        public AccountCommand(AccountKey key, TIntent intent)
            : base(key, intent) { }
    }
}
