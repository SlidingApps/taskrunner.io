
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Validations
{
    public class TenantQueryValidator
        : AbstractValidator<TenantQuery>
    {
        public TenantQueryValidator()
        {
            RuleFor(c => c.OrganizationId).NotEmpty();
            RuleFor(c => c.OrganizationId).Must(this.BeAuthorizedForTenant);
        }

        private bool BeAuthorizedForTenant(Guid oragizationId)
        {
            return true;
        }
    }
}
