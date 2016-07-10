
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent
{
    public class SendAccountConfirmationLink
        : IIntent
    {
        public string UserName { get; set; }
    }
}
