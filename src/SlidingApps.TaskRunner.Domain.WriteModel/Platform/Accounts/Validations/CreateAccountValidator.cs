
using FluentValidation;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Validations
{
    public class CreateAccountValidator
        : AbstractValidator<AccountCommand<CreateAccount>>
    {
        public CreateAccountValidator()
        {
            this.RuleFor(x => x.TenantId).NotEmpty().WithMessage("TenantId cannot be empty");
        }
    }
}
