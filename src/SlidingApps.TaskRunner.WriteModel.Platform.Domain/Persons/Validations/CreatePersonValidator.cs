
using FluentValidation;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Validations
{
    public class CreatePersonValidator
        : AbstractValidator<PersonCommand<CreatePerson>>
    {
        public CreatePersonValidator()
        {
            this.RuleFor(x => x.Intent.EmailAddress).NotEmpty();
        }
    }
}
