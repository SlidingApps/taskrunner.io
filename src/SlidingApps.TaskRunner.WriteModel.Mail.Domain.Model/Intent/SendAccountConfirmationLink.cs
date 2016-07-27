
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendAccountConfirmationLink
        : IIntent
    {
        public string Recipient { get; set; }

        public string UserName { get; set; }
    }
}
