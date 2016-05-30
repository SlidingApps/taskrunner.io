
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model
{
    public class MailCommand<TIntent>
        : Command<TIntent> where TIntent : IIntent
    {
        public MailCommand()
            : base() { }

        public MailCommand(TIntent intent)
            : base(intent) { }
    }
}
