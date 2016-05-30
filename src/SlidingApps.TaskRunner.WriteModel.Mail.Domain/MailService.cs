
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public class MailService
        : ICommandHandler<MailCommand<SendResetPasswordLink>>
    {
        public ICommandResult Handle(MailCommand<SendResetPasswordLink> message)
        {
            throw new NotImplementedException();
        }
    }
}
