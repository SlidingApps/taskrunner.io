
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Intents
{
    public class SendResetPasswordLink
        : MailIntent
    {
        public string ResetPasswordUrl { get; set; }

        public string UserName { get; set; }
    }
}
