
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
    public interface IWithDomainEvents
    {
        List<IDomainEvent> DomainEvents { get; }
    }
}
