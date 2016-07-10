
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendResetPasswordLink
        : IIntent
    {
        public string UserName { get; set; }

        public string Link { get; set; }
    }
}
