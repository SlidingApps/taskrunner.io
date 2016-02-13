
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IDomainEventMessagePublisher
    {
        void Publish(IDomainEvent domainEvent);

        void Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}
