
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class CreateAccount
        : IIntent
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Info { get; set; }
    }
}
