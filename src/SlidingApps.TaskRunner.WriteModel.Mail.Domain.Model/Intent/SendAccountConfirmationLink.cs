
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendAccountConfirmationLink
        : IIntent
    {
        public string UserName { get; set; }
    }
}
