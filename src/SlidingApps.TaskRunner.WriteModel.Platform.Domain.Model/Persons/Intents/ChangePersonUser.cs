
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents
{
    public class ChangePersonUser
        : IIntent
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
