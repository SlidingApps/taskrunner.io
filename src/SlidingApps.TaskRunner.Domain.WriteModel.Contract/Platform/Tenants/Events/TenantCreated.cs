
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Events
{
    public class TenantCreated
         : DomainEvent
    {
        public TenantCreated(CreateTenant command)
            : base(command.Id)
        {
            this.OrganizationId = Guid.NewGuid();
            this.Code = command.Code;
            this.Name = command.Name;
            this.Description = command.Description;
            this.ValidFrom = command.ValidFrom.HasValue ? command.ValidFrom.Value : Constant.MIN_DATE_VALUE;
            this.ValidUntil = command.ValidUntil.HasValue ? command.ValidUntil.Value : Constant.OPEN_END_DATE_VALUE;
        }

        public Guid OrganizationId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
