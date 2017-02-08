
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent
{
    public class SendResetPasswordLink
        : IMailIntent
    {
        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string ResetPasswordUrl { get; set; }

        public string TextContentTemplate { get; set; }

        public string HtmlContentTemplate { get; set; }

        public string UserName { get; set; }

        public MailStatus Status { get; set; }
    }
}
