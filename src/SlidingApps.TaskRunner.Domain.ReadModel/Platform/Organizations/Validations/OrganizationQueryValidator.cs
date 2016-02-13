
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Validations
{
    public class OrganizationQueryValidator
        : AbstractValidator<OrganizationQuery>
    {
        public OrganizationQueryValidator()
        {
            RuleFor(c => c.OrganizationId).NotEmpty();
            RuleFor(c => c.OrganizationId).Must(this.BeAuthorizedForOrganization);
        }

        private bool BeAuthorizedForOrganization(Guid oragizationId)
        {
            return true;
        }
    }
}
