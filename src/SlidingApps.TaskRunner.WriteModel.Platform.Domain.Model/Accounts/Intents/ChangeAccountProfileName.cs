
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents
{
    public class ChangeAccountProfileName
        : IIntent
    {
        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
