
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Validations
{
    public class CreatePersonValidator
        : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidator()
        {
            this.RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId cannot be empty");
            this.RuleFor(x => x.StartDate).NotEqual(DateTime.MinValue);
            this.RuleFor(x => x.EndDate).NotEqual(DateTime.MinValue);
            this.RuleFor(x => x.StartDate).LessThanOrEqualTo(x=>x.EndDate);
        }
    }
}
