
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class ChangeAccountUserPeriod
        : IIntent
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
