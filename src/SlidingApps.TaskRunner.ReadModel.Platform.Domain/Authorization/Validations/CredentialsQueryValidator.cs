
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Queries;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Validations
{
    public class CredentialsQueryValidator
        : AbstractValidator<AccountValidityQuery>
    {
        public CredentialsQueryValidator()
        {
            this.RuleFor(c => c.Username).NotEmpty();
            this.RuleFor(c => c.Password).NotEmpty();
        }
    }
}
