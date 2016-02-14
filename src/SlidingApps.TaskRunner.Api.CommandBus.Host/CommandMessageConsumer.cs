
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Commands;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using MassTransit;
using MediatR;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    public class CommandMessageConsumer :
        IConsumer<CommandMessage<CreateOrganization>>,
        IConsumer<CommandMessage<CreatePerson>>,
        IConsumer<CommandMessage<ChangePersonName>>,
        IConsumer<CommandMessage<ChangePersonPeriod>>
    {
        private readonly IMediator mediator;

        public CommandMessageConsumer() { }

        public CommandMessageConsumer(IMediator mediator)
            : this()
        {
            this.mediator = mediator;
        }

        public Task Consume(ConsumeContext<CommandMessage<CreateOrganization>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<CreatePerson>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<ChangePersonName>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<ChangePersonPeriod>> context)
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
