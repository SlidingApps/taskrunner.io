
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Events
{
    public abstract class PersonEvent<TProps>
        : DomainEvent where TProps : IIntent
    {
        public PersonEvent()
            : base() { }

        protected PersonEvent(Guid correlationId)
            : base(correlationId) { }

        public PersonEvent(Commands.PersonCommand<TProps> command)
            : this(command.Id)
        {
            this.TenantId = command.TenantId;
            this.PersonId = command.PersonId;
            this.Props = command.Intent;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }

        public TProps Props { get; set; }
    }
}
