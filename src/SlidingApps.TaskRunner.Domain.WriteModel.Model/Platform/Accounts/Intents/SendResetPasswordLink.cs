
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
