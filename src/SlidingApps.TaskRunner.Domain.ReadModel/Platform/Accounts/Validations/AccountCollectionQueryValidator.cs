
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Validations
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
