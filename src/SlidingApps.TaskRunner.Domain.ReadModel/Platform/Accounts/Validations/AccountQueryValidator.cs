
using FluentValidation;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Validations
{
    public class AccountQueryValidator
        : AbstractValidator<AccountQuery>
    {
        public AccountQueryValidator()
        {
            RuleFor(c => c.TenantId).NotEmpty();
            RuleFor(c => c.TenantId).Must(this.BeAuthorizedForTenant);

            RuleFor(c => c.PersonId).NotEmpty();
            RuleFor(c => c.PersonId).Must(this.BeAuthorizedForAccount);
        }

        private bool BeAuthorizedForTenant(Guid tenantId)
        {
            return true;
        }

        private bool BeAuthorizedForAccount(Guid accountId)
        {
            return true;
        }
    }
}
