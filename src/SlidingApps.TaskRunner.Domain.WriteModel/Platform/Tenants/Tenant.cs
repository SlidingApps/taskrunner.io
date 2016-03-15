
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants
{
    public class Tenant
        : DomainEntity<Guid, Entities.Tenant>, IWithValidator<Tenant>
    {
        private readonly IValidator<Tenant> validator;

        public Tenant(IValidator<Tenant> validator)
            : base() 
		{
            Argument.InstanceIsRequired(validator, "validator");

            this.validator = validator;
        }

        public Tenant(Entities.Tenant entity, IValidator<Tenant> validator)
            : this(validator)
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
            if (this.entity.Info == null)
            {
                this.entity.Info = new Entities.TenantInfo(Guid.NewGuid());
                this.entity.Info.Tenant = this.entity;
            };
        }

        private readonly static DateTime DEFAULT_VALIDFROM_DATE = new DateTime(1900, 01, 01);
        private readonly static DateTime DEFAULT_VALIDUNTIL_DATE = new DateTime(9999, 01, 01);

        public string Code
        {
            get { return this.entity.Code; }
            private set { this.entity.Code = value; }
        }

        public string Name
        {
            get { return this.entity.Info.Name; }
            private set { this.entity.Info.Name = value; }
        }

        public string Description
        {
            get { return this.entity.Info.Description; }
            private set { this.entity.Info.Description = value; }
        }

        public DateTime ValidFrom
        {
            get { return this.entity.Info.ValidFrom; }
            private set { this.entity.Info.ValidFrom = value; }
        }

        public DateTime ValidUntil
        {
            get { return this.entity.Info.ValidUntil; }
            private set { this.entity.Info.ValidUntil = value; }
        }

        public IDomainEvent Apply(TenantCommand<CreateTenant> command)
        {
            TenantEvent<CreateTenant> domainEvent = new TenantEvent<CreateTenant>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantEvent<CreateTenant> domainEvent)
        {
            this.Id = domainEvent.TenantId = Guid.NewGuid();
            this.Code = domainEvent.Arguments.Code;
            this.Name = domainEvent.Arguments.Name;
            this.Description = domainEvent.Arguments.Description;
            this.ValidFrom = domainEvent.Arguments.ValidFrom.HasValue ? domainEvent.Arguments.ValidFrom.Value : Tenant.DEFAULT_VALIDFROM_DATE;
            this.ValidUntil = domainEvent.Arguments.ValidUntil.HasValue ? domainEvent.Arguments.ValidUntil.Value : Tenant.DEFAULT_VALIDUNTIL_DATE;

            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
