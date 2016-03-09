
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public class CreatePerson
        : PersonCommand<Intents.CreatePerson>
    {
        public CreatePerson()
            : base() { }

        public CreatePerson(Guid tenantId, Intents.CreatePerson intent)
            : base(tenantId, Guid.NewGuid(), intent) { }
    }
}
