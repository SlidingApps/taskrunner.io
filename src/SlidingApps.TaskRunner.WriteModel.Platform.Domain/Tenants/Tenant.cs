
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

        private List<TenantAccount> accounts;
        public List<TenantAccount> Accounts
        {
            get
            {
                var accounts = new List<TenantAccount>();
                if (this.accounts == null)
                {
                    accounts = this.entity.Accounts.ToList().Select(x => new TenantAccount(x)).ToList();
                }

                return this.accounts = accounts;
            }
            private set { this.accounts = value; }
        }

        public TenantAccount AddAccount(Guid accountId)
        {
            var account = new Entities.TenantAccount(Guid.NewGuid());
            account.Tenant = this.entity;
            account.AccountId = accountId;
            this.entity.Accounts.Add(account);

            var _account = new TenantAccount(account);
            this.Accounts.Add(_account);

            return _account;
        }

        public TenantEvent<CreateTenant> Apply(TenantCommand<CreateTenant> command)
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

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
