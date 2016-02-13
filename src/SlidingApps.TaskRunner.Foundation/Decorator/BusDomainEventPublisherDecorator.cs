﻿
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using MediatR;
using System;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.Decorator
{
    public class BusDomainEventPublisherDecorator<TCommand, TCommandResult>
        : IRequestHandler<TCommand, TCommandResult>
        where TCommand : ICommand<TCommandResult>, IRequest<TCommandResult>
        where TCommandResult : class, ICommandResult
    {
        private readonly IBusConnector connector;

        private readonly IRequestHandler<TCommand, TCommandResult> handler;

        public BusDomainEventPublisherDecorator(IBusConnector connector, IRequestHandler<TCommand, TCommandResult> handler)
        {
            this.connector = connector;
            this.handler = handler;
        }

        public TCommandResult Handle(TCommand command)
        {
            string _command = command.ToJson();

            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, command.Id, "pipeline -> ", this.GetType().Name);
            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "received command", _command);
            TCommandResult events = this.handler.Handle(command);

            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "publish domain events to bus", _command);
            events.ToList().ForEach(de =>
            {
                var _domainEvent = de.ToJson();
                Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "domain event", _domainEvent);

                // Try to get the message type and create an instance.
                Type messageType = DomainEventPublisherTypeCache.Get(de.GetType(), command.Id);
                object message = Activator.CreateInstance(messageType, de);

                // Publish the message on the bus
                Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "publish domain event message", message.ToJson());
                this.connector.PublishEvent(message, command.Id.ToString());

                Logger.Log.DebugFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "domain event published", _domainEvent);
            });

            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, command.Id, "publish domain events to bus completed", _command);

            return events;
        }
    }
}
