
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public abstract class DomainEvent
        : IDomainEvent
    {
        protected DomainEvent()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
        }

        protected DomainEvent(Command command)
            : this()
        {
            this.CorrelationId = command.Id;
        }

        public Guid Id { get; set; }

        public Guid CorrelationId { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public abstract class DomainEvent<TIntent>
        : DomainEvent where TIntent : IIntent
    {
        public DomainEvent()
            : base() { }

        public DomainEvent(Command<TIntent> command)
            : base(command)
        {
            this.Arguments = command.Intent;
        }

        public TIntent Arguments { get; set; }
    }
}
