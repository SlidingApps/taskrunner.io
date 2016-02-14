﻿
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using MassTransit;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.MassTransit
{
    public class MassTransitConnector
        : IBusConnector
    {
        private readonly IBus bus;

        private readonly RabbitMQConfigration rabbitMQConfiguration;

        ISendEndpoint commandEndpoint;

        ISendEndpoint eventEndpoint;

        public MassTransitConnector(IBus bus, RabbitMQConfigration rabbitMQConfiguration)
        {
            this.bus = bus;
            this.rabbitMQConfiguration = rabbitMQConfiguration;
        }

        public async Task SendCommand<TCommand>(TCommand command)
            where TCommand : ICommand<ICommandResult>
        {
            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, command.Id, "submiting command", command.GetType().FullName);
            ISendEndpoint endpoint = this.commandEndpoint ?? (this.commandEndpoint = await this.bus.GetSendEndpoint(this.rabbitMQConfiguration.CommandExchangeUri));
            await endpoint.Send(new CommandMessage<TCommand>(command));

            Logger.Log.DebugFormat(Logger.CORRELATED_CONTENT, command.Id, "command submitted", command.GetType().FullName);
        }

        public async Task PublishEvent<TDomainEventMessage>(TDomainEventMessage domainEventMessage)
            where TDomainEventMessage : class, IDomainEventMessage<IDomainEvent>
        {
            await this.PublishEvent(domainEventMessage, domainEventMessage.Event.CorrelationId.ToString());
        }

        public async Task PublishEvent(object eventMessage, string correlationId)
        {
            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, correlationId, "submiting event", eventMessage.GetType().FullName);
            ISendEndpoint endpoint = this.eventEndpoint ?? (this.eventEndpoint= await this.bus.GetSendEndpoint(this.rabbitMQConfiguration.EventExchangeUri));
            await endpoint.Send(eventMessage);

            Logger.Log.DebugFormat(Logger.CORRELATED_CONTENT, correlationId, "event submitted", eventMessage.GetType().FullName);
        }
    }
}
