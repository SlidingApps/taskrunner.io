
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Validations
{
    public class PersonQueryValidator
        : AbstractValidator<PersonQuery>
    {
        public PersonQueryValidator()
        {
            RuleFor(c => c.OrganizationId).NotEmpty();
            RuleFor(c => c.OrganizationId).Must(this.BeAuthorizedForOrganization);

            RuleFor(c => c.PersonId).NotEmpty();
            RuleFor(c => c.PersonId).Must(this.BeAuthorizedForPerson);
        }

        private bool BeAuthorizedForOrganization(Guid oragizationId)
        {
            return true;
        }

        private bool BeAuthorizedForPerson(Guid oragizationId)
        {
            return true;
        }
    }
}
