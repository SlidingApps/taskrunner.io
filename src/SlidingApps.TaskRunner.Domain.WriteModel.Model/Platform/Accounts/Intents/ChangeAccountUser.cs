
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class ChangeAccountUser
        : IIntent
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
