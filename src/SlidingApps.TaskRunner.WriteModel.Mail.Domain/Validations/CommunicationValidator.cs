
using FluentValidation;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Validations
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
