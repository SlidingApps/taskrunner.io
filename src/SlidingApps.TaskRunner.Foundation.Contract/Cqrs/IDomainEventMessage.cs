
using MediatR;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IDomainEventMessage
        : INotification
    {
        string Type { get; }
    }

    public interface IDomainEventMessage<out TDomainEvent>
        : IDomainEventMessage
        where TDomainEvent : IDomainEvent
    {
        TDomainEvent Event { get; }
    }
}
