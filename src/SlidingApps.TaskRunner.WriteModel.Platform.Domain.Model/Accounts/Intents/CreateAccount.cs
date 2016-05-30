
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents
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
