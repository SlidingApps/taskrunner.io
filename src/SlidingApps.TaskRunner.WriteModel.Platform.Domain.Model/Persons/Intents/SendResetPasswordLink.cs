
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
