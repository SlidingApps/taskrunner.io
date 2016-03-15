
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
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    public class CommandMessageConsumer :
        IConsumer<CommandMessage<TenantCommand<CreateTenant>>>,
        IConsumer<CommandMessage<AccountCommand<CreateAccount>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountProfileName>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountUserPeriod>>>
    {
        private readonly IMediator mediator;

        public CommandMessageConsumer() { }

        public CommandMessageConsumer(IMediator mediator)
            : this()
        {
            this.mediator = mediator;
        }

        public Task Consume(ConsumeContext<CommandMessage<TenantCommand<CreateTenant>>> context)
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
                var _message = context.Message.ToJson();

                Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "consuming message", _message);
                ICommandResult events = this.mediator.Send(context.Message.Command);

                Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, context.Message.Command.Id, "message consumed", _message);
            });
        }
    }
}
