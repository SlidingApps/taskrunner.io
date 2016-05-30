
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string Name { get; set; }
    }
}
