
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
