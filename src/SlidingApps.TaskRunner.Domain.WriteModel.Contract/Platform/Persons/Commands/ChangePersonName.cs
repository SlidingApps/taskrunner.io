
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class ChangePersonName
        : PersonCommand<Intents.ChangePersonName>
    {
        public ChangePersonName()
            : base() { }

        public ChangePersonName(Guid tenantId, Guid personId, Intents.ChangePersonName intent)
            : base(tenantId, personId, intent) { }
    }
}
