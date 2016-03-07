
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Events;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using FluentValidation;
using FluentValidation.Results;
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

        public IDomainEvent Apply(CreateTenant command)
        {
            TenantCreated domainEvent = new TenantCreated(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantCreated domainEvent)
        {
            this.Id = domainEvent.TenantId;
            this.Code = domainEvent.Code;
            this.Name = domainEvent.Name;
            this.Description = domainEvent.Description;
            this.ValidFrom = domainEvent.ValidFrom;
            this.ValidUntil = domainEvent.ValidUntil;

            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
