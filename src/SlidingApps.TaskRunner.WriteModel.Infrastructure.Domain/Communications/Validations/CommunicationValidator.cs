
using FluentValidation;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Validations
{
    public class CommunicationValidator
        : AbstractValidator<Communication<MailCommunicationInfo>>
    {
        public CommunicationValidator()
        {
            this.RuleFor(x => x.Info.Recipient).NotEmpty();
        }
    }
}
