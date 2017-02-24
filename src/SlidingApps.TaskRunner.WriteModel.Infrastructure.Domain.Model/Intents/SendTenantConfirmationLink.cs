
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Intents
{
    public class SendTenantConfirmationLink
        : MailIntent
    {
        public string ConfirmationUrl { get; set; }

        public string Code { get; set; }
    }
}
