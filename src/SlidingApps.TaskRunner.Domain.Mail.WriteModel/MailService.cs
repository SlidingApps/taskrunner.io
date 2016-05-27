
using SlidingApps.TaskRunner.Domain.Mail.WriteModel.Model;
using SlidingApps.TaskRunner.Domain.Mail.WriteModel.Model.Intent;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.Mail.WriteModel
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
