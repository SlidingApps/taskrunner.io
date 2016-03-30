
using System;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IDomainEvent
        : IWithIdentifier<Guid>, IWithCorrelationIdentifier<Guid>
    {
        DateTime Timestamp { get; set; }
    }
}
