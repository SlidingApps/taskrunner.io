
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class ChangePersonPeriod
        : PersonCommand<Intents.ChangePersonPeriod>
    {
        public ChangePersonPeriod()
            : base() { }

        public ChangePersonPeriod(Guid tenantId, Guid personId, Intents.ChangePersonPeriod intent)
            : base(tenantId, personId, intent) { }
    }
}