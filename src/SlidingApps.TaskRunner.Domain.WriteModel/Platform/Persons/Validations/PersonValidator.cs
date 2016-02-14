
using FluentValidation;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Validations
{
    public class PersonValidator
        : AbstractValidator<Person>
    {
        public PersonValidator()
        {
        }
    }
}
