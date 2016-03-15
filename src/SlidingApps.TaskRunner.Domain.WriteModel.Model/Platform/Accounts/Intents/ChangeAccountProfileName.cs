
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class ChangeAccountProfileName
        : IIntent
    {
        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
