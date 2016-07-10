
using System;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public class EntityIdentifier
        : IDomainEventIdentifiers
    {
        public Guid EntityId { get; set; }
    }
}
