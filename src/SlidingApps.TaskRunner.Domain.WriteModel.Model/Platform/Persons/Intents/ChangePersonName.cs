
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents
{
    public class ChangePersonName
        : IIntent
    {
        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}
