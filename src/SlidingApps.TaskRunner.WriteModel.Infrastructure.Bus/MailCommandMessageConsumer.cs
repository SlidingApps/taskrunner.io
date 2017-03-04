
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Model.Communications.Intents;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Bus
{
    public class MailCommandMessageConsumer
        : CommandMessageConsumer,

            IConsumer<MailCommand<SendTenantConfirmationLink>>,
            IConsumer<MailCommand<SendPersonConfirmationLink>>,
            IConsumer<MailCommand<SendResetPasswordLink>>
    {
        public MailCommandMessageConsumer()
        {
        }

        public MailCommandMessageConsumer(IUnitOfWork unitOfWork, IMediator mediator, IBusConnector connector)
            : base(unitOfWork, mediator, connector)
        {
        }

        public Task Consume(ConsumeContext<MailCommand<SendResetPasswordLink>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<MailCommand<SendPersonConfirmationLink>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<MailCommand<SendTenantConfirmationLink>> context)
        {
            return this.ConsumeCommand(context);
        }
    }
}
