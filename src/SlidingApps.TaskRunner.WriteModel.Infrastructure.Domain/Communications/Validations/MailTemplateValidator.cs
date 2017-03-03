
using FluentValidation;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Validations
{
    public class MailTemplateValidator
        : AbstractValidator<MailTemplate>
    {
        public MailTemplateValidator()
        {
            this.RuleFor(x => x.Code).NotEmpty();
            this.RuleFor(x => x.Subject).NotEmpty();
            this.RuleFor(x => x.TextTemplate).NotEmpty();
            this.RuleFor(x => x.HtmlTemplate).NotEmpty();
        }
    }
}
