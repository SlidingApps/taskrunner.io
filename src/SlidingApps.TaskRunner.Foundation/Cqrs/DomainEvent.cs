
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

    public abstract class DomainEvent<TBusinessKey, TDomainEventIdentifiers, TIntent>
        : DomainEvent
        where TBusinessKey : IBusinessKey
        where TDomainEventIdentifiers : class, IDomainEventIdentifiers, new()
        where TIntent : IIntent
    {
        public DomainEvent()
            : base() { }

        public DomainEvent(Command<TBusinessKey, TIntent> command)
            : base(command)
        {
            this.Key = command.Key;
            this.Identifiers = new TDomainEventIdentifiers();
            this.Arguments = command.Intent;
        }

        public TBusinessKey Key { get; set; }

        public TDomainEventIdentifiers Identifiers { get; set; }

        public TIntent Arguments { get; set; }
    }

    public abstract class DomainEvent<TKey, TIntent>
        : DomainEvent<TKey, EntityIdentifier, TIntent>
        where TKey : IBusinessKey
        where TIntent : IIntent
    {
        public DomainEvent()
            : base() { }

        public DomainEvent(Command<TKey, TIntent> command)
            : base(command) { }
    }

    public abstract class DomainEvent<TIntent>
        : DomainEvent<EmptyKey, EntityIdentifier, TIntent>
        where TIntent : IIntent
    {
        public DomainEvent()
            : base() { }

        public DomainEvent(Command<EmptyKey, TIntent> command)
            : base(command) { }
    }
}
