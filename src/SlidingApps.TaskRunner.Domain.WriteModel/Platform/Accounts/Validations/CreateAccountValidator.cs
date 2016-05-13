
using FluentValidation;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Validations
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
