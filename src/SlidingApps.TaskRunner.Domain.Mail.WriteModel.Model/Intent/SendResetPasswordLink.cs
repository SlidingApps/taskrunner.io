
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.Mail.WriteModel.Model.Intent
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
