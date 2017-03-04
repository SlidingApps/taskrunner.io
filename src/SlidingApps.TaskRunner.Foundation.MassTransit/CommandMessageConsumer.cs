
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.MassTransit
{
    public abstract class CommandMessageConsumer
        : ICommandMessageConsumer
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMediator mediator;

        private IBusConnector connector;

        public CommandMessageConsumer() { }

        public CommandMessageConsumer(IUnitOfWork unitOfWork, IMediator mediator, IBusConnector connector)
            : this()
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.connector = connector;
        }

        protected Task ConsumeCommand<TCommand>(ConsumeContext<TCommand> context)
            where TCommand : class, ICommand<ICommandResult>
        {
            return Task.Run(() =>
            {
                Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, context.Message.Id, "starting unit of work", unitOfWork.GetType().FullName);
                this.unitOfWork.Start(() =>
                {
                    Logger.Log.DebugFormat(Logger.CORRELATED_CONTENT, context.Message.Id, "unit of work started", unitOfWork.GetType().FullName);
                    var _message = context.Message.ToJson();

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "consuming message", _message);
                    ICommandResult events = this.mediator.Send(context.Message);

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "message consumed", _message);

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "publishing event", string.Format("{0} event(s)", events.Count()));
                    events.ToList().OrderBy(x => x.Timestamp).ToList()
                        .ForEach(domainEvent =>
                        {
                            var _domainEvent = domainEvent.ToJson();
                            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "domain event", _domainEvent);

                            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "publish event", _domainEvent);
                            this.connector.PublishEvent(domainEvent, context.Message.Id.ToString());

                            Logger.Log.DebugFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "domain event published", _domainEvent);
                        });

                    Logger.Log.DebugFormat(Logger.CORRELATED_MESSAGE, context.Message.Id, "events published");
                    Logger.Log.DebugFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Id, "unit of work handled command", _message);
                }, (context.Message is IWithIdentifier<Guid>) ? ((IWithIdentifier<Guid>)context.Message).Id.ToString() : string.Empty);

                Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, context.Message.Id, "unit of work completed", unitOfWork.GetType().FullName);
            });
        }
    }
}
