
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class ChangeAccountUserPeriod
        : IIntent
    {
        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
