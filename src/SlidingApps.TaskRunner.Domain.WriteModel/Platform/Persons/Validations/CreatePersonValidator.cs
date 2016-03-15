
using FluentValidation;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Validations
{
    public class CreatePersonValidator
        : AbstractValidator<PersonCommand<CreatePerson>>
    {
        public CreatePersonValidator()
        {
            this.RuleFor(x => x.TenantId).NotEmpty().WithMessage("TenantId cannot be empty");
            this.RuleFor(x => x.Intent.StartDate).NotEqual(DateTime.MinValue);
            this.RuleFor(x => x.Intent.EndDate).NotEqual(DateTime.MinValue);
            this.RuleFor(x => x.Intent.StartDate).LessThanOrEqualTo(x=>x.Intent.EndDate);
        }
    }
}
