
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public class PersonPeriodChanged
        : PersonEvent<Intents.ChangePersonPeriod>
    {
        public PersonPeriodChanged()
            : base() { }

        public PersonPeriodChanged(ChangePersonPeriod command)
            : base(command) { }
    }
}
