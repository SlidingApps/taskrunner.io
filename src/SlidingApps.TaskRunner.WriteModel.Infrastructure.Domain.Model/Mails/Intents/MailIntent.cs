
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Mails.Intents
{
    public abstract class MailIntent
        : IMailIntent
    {
        public string HtmlContentTemplate { get; set; }

        public string Recipient { get; set; }

        public MailStatus Status { get; set; }

        public string Subject { get; set; }

        public string TextContentTemplate { get; set; }
    }
}
