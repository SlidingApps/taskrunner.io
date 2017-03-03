
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications.Intents
{
    public class SendPersonConfirmationLink
        : MailIntent
    {
        public string ConfirmationUrl { get; set; }

        public string UserName { get; set; }
    }
}
