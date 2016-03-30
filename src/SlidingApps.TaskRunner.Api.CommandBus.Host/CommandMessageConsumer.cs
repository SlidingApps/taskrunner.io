
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    public class CommandMessageConsumer :
        IConsumer<CommandMessage<TenantCommand<CreateTenant>>>,
        IConsumer<CommandMessage<TenantCommand<ChangeTenantInfo>>>,
        IConsumer<CommandMessage<AccountCommand<CreateAccount>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountProfileName>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountUserPeriod>>>
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

        public Task Consume(ConsumeContext<CommandMessage<TenantCommand<CreateTenant>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<TenantCommand<ChangeTenantInfo>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<AccountCommand<CreateAccount>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<AccountCommand<ChangeAccountProfileName>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<AccountCommand<ChangeAccountUserPeriod>>> context)
        {
            return this.ConsumeCommand(context);
        }

        private Task ConsumeCommand<TCommand>(ConsumeContext<CommandMessage<TCommand>> context)
            where TCommand : ICommand<ICommandResult>
        {
            return Task.Run(() =>
            {
                Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, context.Message.Command.Id, "starting unit of work", unitOfWork.GetType().FullName);
                this.unitOfWork.Start(() =>
                {
                    Logger.Log.DebugFormat(Logger.CORRELATED_CONTENT, context.Message.Command.Id, "unit of work started", unitOfWork.GetType().FullName);
                    var _message = context.Message.ToJson();

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "consuming message", _message);
                    ICommandResult events = this.mediator.Send(context.Message.Command);

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "message consumed", _message);

                    Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "publishing event", string.Format("{0} event(s)", events.Count()));
                    events.ToList().OrderBy(x => x.Timestamp).ToList()
                        .ForEach(x => 
                            {
                                Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "publish event", x.ToJson());
                                this.connector.PublishEvent(x, context.Message.Command.Id.ToString());
                            });

                    Logger.Log.DebugFormat(Logger.CORRELATED_MESSAGE, context.Message.Command.Id, "events published");
                    Logger.Log.DebugFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "unit of work handled command", _message);
                }, (context.Message.Command is IWithIdentifier<Guid>) ? ((IWithIdentifier<Guid>)context.Message.Command).Id.ToString() : string.Empty);

                Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, context.Message.Command.Id, "unit of work completed", unitOfWork.GetType().FullName);
            });
        }
    }
}
