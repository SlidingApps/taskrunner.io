
using MediatR;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IEventHandler<in TDomainEventMessage>
        : INotificationHandler<TDomainEventMessage>
        where TDomainEventMessage : IDomainEventMessage<IDomainEvent> { }
}
