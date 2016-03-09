
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonCreated
        : PersonEvent<Intents.CreatePerson>
    {
        public PersonCreated()
            : base() { }

        public PersonCreated(CreatePerson command)
            : base(command) { }
    }
}
