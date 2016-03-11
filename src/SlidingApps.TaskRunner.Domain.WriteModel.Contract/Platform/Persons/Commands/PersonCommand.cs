
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands
{
    public sealed class PersonCommand<TIntent>
        : Command<TIntent> where TIntent : IIntent
    {
        public PersonCommand()
            :base() { }

        public PersonCommand(Guid tenantId, TIntent intent)
            : base(intent)
        {
            this.TenantId = tenantId;
        }

        public PersonCommand(Guid tenantId, Guid personId, TIntent intent)
            : base(intent)
        {
            this.TenantId = tenantId;
            this.PersonId = personId;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }
    }
}
