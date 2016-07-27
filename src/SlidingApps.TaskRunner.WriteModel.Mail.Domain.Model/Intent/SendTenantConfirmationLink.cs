
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendTenantConfirmationLink
        : IIntent
    {
        public string Recipient { get; set; }

        public string Code { get; set; }
    }
}
