
using FluentValidation;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Queries;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Validations
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
