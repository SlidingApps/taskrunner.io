
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Validations
{
    public class PersonCollectionQueryValidator
        : AbstractValidator<PersonCollectionQuery>
    {
        public PersonCollectionQueryValidator()
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
