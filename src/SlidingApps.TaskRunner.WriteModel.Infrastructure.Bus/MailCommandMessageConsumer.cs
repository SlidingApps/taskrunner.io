
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Mails;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Mails.Intents;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Bus
{
    public class MailCommandMessageConsumer
        : CommandMessageConsumer,

        IConsumer<CommandMessage<MailCommand<SendTenantConfirmationLink>>>,
        IConsumer<CommandMessage<MailCommand<SendPersonConfirmationLink>>>,
        IConsumer<CommandMessage<MailCommand<SendResetPasswordLink>>>
    {
        public MailCommandMessageConsumer() { }

        public MailCommandMessageConsumer(IUnitOfWork unitOfWork, IMediator mediator, IBusConnector connector)
            : base(unitOfWork, mediator, connector) { }

        public Task Consume(ConsumeContext<CommandMessage<MailCommand<SendResetPasswordLink>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<MailCommand<SendPersonConfirmationLink>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<MailCommand<SendTenantConfirmationLink>>> context)
        {
            return this.ConsumeCommand(context);
        }
    }
}
