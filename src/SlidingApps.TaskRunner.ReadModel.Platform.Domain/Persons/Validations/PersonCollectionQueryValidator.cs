﻿
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Validations
{
    public class PersonCollectionQueryValidator
        : AbstractValidator<PersonCollectionQuery>
    {
        public PersonCollectionQueryValidator()
        {
            RuleFor(c => c.TenantId).NotEmpty();
            RuleFor(c => c.TenantId).Must(this.BeAuthorizedForTenant);
        }

        private bool BeAuthorizedForTenant(Guid tenantId)
        {
            return true;
        }
    }
}
