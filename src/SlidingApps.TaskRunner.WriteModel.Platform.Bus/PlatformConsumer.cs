
using MassTransit;
using MediatR;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
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

        IConsumer<TenantCommand<CreateTenant>>,
        IConsumer<TenantCommand<ChangeTenantInfo>>,
        IConsumer<PersonCommand<CreatePerson>>,
        IConsumer<PersonCommand<ChangePersonIdentityName>>,
        IConsumer<PersonCommand<ChangePersonUserPeriod>>,
        IConsumer<PersonCommand<SendConfirmationLink>>,
        IConsumer<PersonCommand<SendResetPasswordLink>>
    {
        public PlatformConsumer() { }

        public PlatformConsumer(IUnitOfWork unitOfWork, IMediator mediator, IBusConnector connector)
            : base(unitOfWork, mediator, connector) { }

        public Task Consume(ConsumeContext<TenantCommand<CreateTenant>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<TenantCommand<ChangeTenantInfo>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<PersonCommand<CreatePerson>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<PersonCommand<ChangePersonIdentityName>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<PersonCommand<ChangePersonUserPeriod>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<PersonCommand<SendConfirmationLink>> context)
        {
            return this.ConsumeCommand(context);
        }

        public Task Consume(ConsumeContext<PersonCommand<SendResetPasswordLink>> context)
        {
            return this.ConsumeCommand(context);
        }        
    }
}
