
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public class DomainEventMessage<TDomainEvent>
        : IDomainEventMessage<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        public DomainEventMessage(TDomainEvent @event)
        {
            this.Event = @event;
        }

        public string Type { get { return this.Event.GetType().ToFriendlyName(); } }

        public TDomainEvent Event { get; private set; }
    }
}
