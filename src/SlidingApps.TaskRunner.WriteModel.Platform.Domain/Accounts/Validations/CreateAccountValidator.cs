
using FluentValidation;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Accounts.Validations
{
    public class CreateAccountValidator
        : AbstractValidator<AccountCommand<CreateAccount>>
    {
        public CreateAccountValidator()
        {
            this.RuleFor(x => x.Intent.EmailAddress).NotEmpty();
        }
    }
}
