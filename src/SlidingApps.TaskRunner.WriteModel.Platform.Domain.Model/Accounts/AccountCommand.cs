
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts
{
    public class AccountCommand<TIntent>
        : Command<TIntent> where TIntent : IIntent
    {
        public AccountCommand()
            :base() { }

        public AccountCommand(Guid accountId, TIntent intent)
            : base(intent)
        {
            this.AccountId = accountId;
        }

        public Guid AccountId { get; set; }
    }
}
