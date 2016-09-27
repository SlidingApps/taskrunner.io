
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Bus
{
    public class PlatformConsumer 
        : CommandMessageConsumer,

        IConsumer<CommandMessage<TenantCommand<CreateTenant>>>,
        IConsumer<CommandMessage<TenantCommand<ChangeTenantInfo>>>,
        IConsumer<CommandMessage<AccountCommand<CreateAccount>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountProfileName>>>,
        IConsumer<CommandMessage<AccountCommand<ChangeAccountUserPeriod>>>,
        IConsumer<CommandMessage<AccountCommand<SendConfirmationLink>>>,
        IConsumer<CommandMessage<AccountCommand<SendResetPasswordLink>>>
    {
        public PlatformConsumer() { }

        public PlatformConsumer(IUnitOfWork unitOfWork, IMediator mediator, IBusConnector connector)
            : base(unitOfWork, mediator, connector) { }

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

        public Task Consume(ConsumeContext<CommandMessage<AccountCommand<SendConfirmationLink>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<AccountCommand<SendResetPasswordLink>>> context)
        {
            return this.ConsumeCommand(context);
        }        
    }
}
