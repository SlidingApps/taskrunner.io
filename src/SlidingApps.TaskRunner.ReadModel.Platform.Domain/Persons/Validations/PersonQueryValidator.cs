
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Validations
{
    public class PersonQueryValidator
        : AbstractValidator<PersonQuery>
    {
        public PersonQueryValidator()
        {
            RuleFor(c => c.Username).NotEmpty();
            RuleFor(c => c.Username).Must(this.BeAuthorizedForAccount);
        }

        private bool BeAuthorizedForTenant(Guid tenantId)
        {
            return true;
        }

        private bool BeAuthorizedForAccount(string username)
        {
            return true;
        }
    }
}
