
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.MessageBus
{
    public interface IBusConnector
    {
        Task SendCommand<TCommand>(TCommand command)
            where TCommand : class, ICommand<ICommandResult>;

        Task PublishEvent<TDomainEvent>(TDomainEvent domainEvent, string correlationId)
            where TDomainEvent : class, IDomainEvent;
    }
}
