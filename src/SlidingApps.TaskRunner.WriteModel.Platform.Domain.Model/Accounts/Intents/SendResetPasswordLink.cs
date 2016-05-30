
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
