
using FluentValidation;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Validations
{
    public class PersonValidator
        : AbstractValidator<Person>
    {
        public PersonValidator()
        {
        }
    }
}
