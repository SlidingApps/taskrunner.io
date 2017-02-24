
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model
{
    public class MailCommand<TIntent>
        : Command<EmptyKey, TIntent> where TIntent : IIntent
    {
        public MailCommand()
            : base() { }

        public MailCommand(TIntent intent)
            : base(new EmptyKey(), intent) { }
    }
}
