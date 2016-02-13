
using MediatR;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IDomainEventMessage<out TDomainEvent>
        : INotification
        where TDomainEvent : IDomainEvent
    {
        string Type { get; }

        TDomainEvent Event { get; }
    }
}
