
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model
{
    public sealed class MailEvent<TProps> 
        : DomainEvent<TProps>, IDomainEvent
    where TProps : IIntent
    {
        public MailEvent()
            : base() { }

        public MailEvent(MailCommand<TProps> command)
            : base(command) { }
    }
}
