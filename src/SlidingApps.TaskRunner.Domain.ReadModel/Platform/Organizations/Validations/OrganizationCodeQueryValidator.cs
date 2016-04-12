
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries;
using FluentValidation;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Validations
{
    public class OrganizationCodeQueryValidator
        : AbstractValidator<OrganizationCodeQuery>
    {
        public OrganizationCodeQueryValidator()
        {
            RuleFor(c => c.Code).NotEmpty();
        }
    }
}
