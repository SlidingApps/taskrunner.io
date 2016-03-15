
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public sealed class PersonEvent<TProps>
        : DomainEvent<TProps> where TProps : IIntent
    {
        public PersonEvent()
            : base() { }

        public PersonEvent(PersonCommand<TProps> command)
            : base(command)
        {
            this.TenantId = command.TenantId;
            this.PersonId = command.PersonId;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }
    }
}
