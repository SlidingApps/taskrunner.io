
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Validations
{
    public class AccountCollectionQueryValidator
        : AbstractValidator<AccountCollectionQuery>
    {
        public AccountCollectionQueryValidator()
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
