
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent
{
    public interface IMailIntent
        : IIntent
    {
        string Recipient { get; set; }

        string Subject { get; set; }

        string TextContentTemplate { get; set; }

        string HtmlContentTemplate { get; set; }

        MailStatus Status { get; set; }
    }
}
