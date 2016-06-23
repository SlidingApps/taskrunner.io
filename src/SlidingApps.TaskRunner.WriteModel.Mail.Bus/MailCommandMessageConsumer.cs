
using MassTransit;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent;
using System;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Bus
{
    public class MailCommandMessageConsumer
        : CommandMessageConsumer,

        IConsumer<CommandMessage<MailCommand<SendTenantConfirmationLink>>>
    {
        public Task Consume(ConsumeContext<CommandMessage<MailCommand<SendTenantConfirmationLink>>> context)
        {
            throw new NotImplementedException();
        }
    }
}
