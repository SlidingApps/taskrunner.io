
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public class MailService :
        ICommandHandler<MailCommand<SendTenantConfirmationLink>>,
        ICommandHandler<MailCommand<SendAccountConfirmationLink>>,
        ICommandHandler<MailCommand<SendResetPasswordLink>>
    {
        public ICommandResult Handle(MailCommand<SendTenantConfirmationLink> command)
        {
            MailGun.SendSimpleMessage(
                new MailParameters(
                    "taskrunner.io",
                    "TaskRunner <no-reply@taskrunner.io>",
                    "Confirm tenant",
                    "Click on the following link to confirm the tenant.",
                    "Click on the following link to confirm the tenant.",
                    "peter.vyvey@gmail.com")
                );

            return new CommandResult(command.Id);
        }

        public ICommandResult Handle(MailCommand<SendAccountConfirmationLink> command)
        {
            MailGun.SendSimpleMessage(
                new MailParameters(
                    "taskrunner.io",
                    "TaskRunner <no-reply@taskrunner.io>",
                    "Confirm account",
                    "Click on the following link to confirm your account.",
                    "Click on the following link to confirm your account.",
                    "peter.vyvey@gmail.com")
                );

            return new CommandResult(command.Id);
        }

        public ICommandResult Handle(MailCommand<SendResetPasswordLink> command)
        {
            MailGun.SendSimpleMessage(
                new MailParameters(
                    "taskrunner.io", 
                    "TaskRunner <no-reply@taskrunner.io>", 
                    "Reset password", 
                    "Click on the following link to reset your password.",
                    "Click on the following link to reset your password.", 
                    "peter.vyvey@gmail.com")
                );

            return new CommandResult(command.Id);
        }
    }
}
