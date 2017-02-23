
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents
{
    public class CreatePerson
        : IIntent
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Info { get; set; }
    }
}
