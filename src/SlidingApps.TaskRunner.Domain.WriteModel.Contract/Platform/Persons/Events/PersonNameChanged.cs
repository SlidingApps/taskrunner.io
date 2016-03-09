
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonNameChanged
        : PersonEvent<Intents.ChangePersonName>
    {
        public PersonNameChanged()
            : base() { }

        public PersonNameChanged(ChangePersonName command)
            : base(command) { }
    }
}
