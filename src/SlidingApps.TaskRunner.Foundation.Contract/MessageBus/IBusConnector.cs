
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.MessageBus
{
    public interface IBusConnector
    {
        Task SendCommand<TCommand>(TCommand command)
            where TCommand : ICommand<ICommandResult>;

        Task PublishEvent(object eventMessage, string correlationId);

        Task PublishEvent<TDomainEventMessage>(TDomainEventMessage domainEventMessage)
            where TDomainEventMessage : class, IDomainEventMessage<IDomainEvent>;
    }
}
