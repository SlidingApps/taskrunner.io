
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants
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

        public DateTime CreationTime
        {
            get { return this.entity.Info.CreationTime; }
            private set { this.entity.Info.CreationTime = value; }
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

        public EntityStatus Status
        {
            get { return this.entity.Info.Status; }
            private set { this.entity.Info.Status = value; }
        }

        public string Link
        {
            get { return this.entity.Info.Link; }
            private set { this.entity.Info.Link = value; }
        }

        private List<TenantPerson> persons;
        public List<TenantPerson> Persons
        {
            get
            {
                var accounts = new List<TenantPerson>();
                if (this.persons == null)
                {
                    accounts = this.entity.Persons.ToList().Select(x => new TenantPerson(x)).ToList();
                }

                return this.persons = accounts;
            }
            private set { this.persons = value; }
        }

        public TenantPerson AddPerson(Guid personId)
        {
            var person = new Entities.TenantPerson(Guid.NewGuid());
            person.Tenant = this.entity;
            person.PersonId = personId;
            this.entity.Persons.Add(person);

            var _account = new TenantPerson(person);
            this.Persons.Add(_account);

            return _account;
        }

        private List<TenantDomain> domains;
        public List<TenantDomain> Domains
        {
            get
            {
                var domains = new List<TenantDomain>();
                if (this.persons == null)
                {
                    domains = this.entity.Domains.ToList().Select(x => new TenantDomain(x)).ToList();
                }

                return this.domains = domains;
            }
            private set { this.domains = value; }
        }

        public TenantDomain AddDefaultDomain()
        {
            var domain = new TenantDomain();
            domain.Code = "#";
            domain.Name = "Default domain";
            domain.Description = "Default domain";

            domain.SetTenant(this.entity);

            this.AddDomain(domain);

            return domain;
        }

        public TenantDomain AddDomain(TenantDomain domain)
        {
            this.entity.Domains.Add(domain.GetDataEntity());
            this.Domains.Add(domain);

            return domain;
        }

        public TenantEvent<CreateTenant> Apply(TenantCommand<CreateTenant> command)
        {
            TenantEvent<CreateTenant> domainEvent = new TenantEvent<CreateTenant>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantEvent<CreateTenant> domainEvent)
        {
            this.Id = domainEvent.Identifiers.EntityId = Guid.NewGuid();
            this.Code = domainEvent.Arguments.Code;
            this.Name = domainEvent.Arguments.Name;
            this.Description = domainEvent.Arguments.Description;
            this.CreationTime = DateTime.UtcNow;
            this.ValidFrom = domainEvent.Arguments.ValidFrom.HasValue ? domainEvent.Arguments.ValidFrom.Value : Tenant.DEFAULT_VALIDFROM_DATE;
            this.ValidUntil = domainEvent.Arguments.ValidUntil.HasValue ? domainEvent.Arguments.ValidUntil.Value : Tenant.DEFAULT_VALIDUNTIL_DATE;
            this.Status = EntityStatus.UNCONFIRMED;
            this.Link = Guid.NewGuid().ToString();

            this.DomainEvents.Add(domainEvent);
        }

        public TenantEvent<ChangeTenantInfo> Apply(TenantCommand<ChangeTenantInfo> command)
        {
            TenantEvent<ChangeTenantInfo> domainEvent = new TenantEvent<ChangeTenantInfo>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantEvent<ChangeTenantInfo> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;
            this.Description = domainEvent.Arguments.Description;

            this.DomainEvents.Add(domainEvent);
        }

        public TenantEvent<ConfirmTenant> Apply(TenantCommand<ConfirmTenant> command)
        {
            TenantEvent<ConfirmTenant> domainEvent = new TenantEvent<ConfirmTenant>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(TenantEvent<ConfirmTenant> domainEvent)
        {
            this.DomainEvents.Add(domainEvent);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
