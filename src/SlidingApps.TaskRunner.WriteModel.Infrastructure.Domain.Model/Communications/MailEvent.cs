
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications
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
