
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications
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
