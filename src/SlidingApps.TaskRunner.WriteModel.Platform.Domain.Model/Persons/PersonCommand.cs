
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons
{
    public class PersonCommand<TIntent>
        : Command<PersonKey, TIntent> where TIntent : IIntent
    {
        public PersonCommand()
            : base() { }

        public PersonCommand(TIntent intent)
            : base(PersonKey.Empty, intent) { }

        public PersonCommand(string name, TIntent intent)
            : base(new PersonKey(name), intent) { }

        public PersonCommand(PersonKey key, TIntent intent)
            : base(key, intent) { }
    }
}
