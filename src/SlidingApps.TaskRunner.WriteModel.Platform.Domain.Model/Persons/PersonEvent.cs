
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons
{
    public sealed class PersonEvent<TProps>
        : DomainEvent<PersonKey, TProps>, IDomainEvent
        where TProps : IIntent
    {
        public PersonEvent()
            : base() { }

        public PersonEvent(PersonCommand<TProps> command)
            : base(command) { }
    }
}
