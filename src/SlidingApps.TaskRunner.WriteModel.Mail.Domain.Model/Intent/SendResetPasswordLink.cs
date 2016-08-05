
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string ContentTemplate { get; set; }

        public string UserName { get; set; }

        public string Link { get; set; }

        public MailStatus Status { get; set; }
    }
}
