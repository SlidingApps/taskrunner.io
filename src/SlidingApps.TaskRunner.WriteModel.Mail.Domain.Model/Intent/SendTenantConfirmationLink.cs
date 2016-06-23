
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendTenantConfirmationLink
        : IIntent
    {
        public string Code { get; set; }
    }
}
