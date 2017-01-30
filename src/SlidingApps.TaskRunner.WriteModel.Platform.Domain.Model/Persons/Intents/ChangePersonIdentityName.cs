
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents
{
    public class ChangePersonIdentityName
        : IIntent
    {
        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
