
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Bus
{
    public class PlatformConsumer 
        : CommandMessageConsumer,

        IConsumer<CommandMessage<TenantCommand<CreateTenant>>>,
        IConsumer<CommandMessage<TenantCommand<ChangeTenantInfo>>>,
        IConsumer<CommandMessage<PersonCommand<CreatePerson>>>,
        IConsumer<CommandMessage<PersonCommand<ChangePersonIdentityName>>>,
        IConsumer<CommandMessage<PersonCommand<ChangePersonUserPeriod>>>,
        IConsumer<CommandMessage<PersonCommand<SendConfirmationLink>>>,
        IConsumer<CommandMessage<PersonCommand<SendResetPasswordLink>>>
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

        public Task Consume(ConsumeContext<CommandMessage<PersonCommand<CreatePerson>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<PersonCommand<ChangePersonIdentityName>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<PersonCommand<ChangePersonUserPeriod>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<PersonCommand<SendConfirmationLink>>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<CommandMessage<PersonCommand<SendResetPasswordLink>>> context)
        {
            return this.ConsumeCommand(context);
        }        
    }
}
