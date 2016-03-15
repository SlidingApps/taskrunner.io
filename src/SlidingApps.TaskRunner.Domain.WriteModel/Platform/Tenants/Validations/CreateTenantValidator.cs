
using FluentValidation;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Validations
{
    class CreateTenantValidator
        : AbstractValidator<TenantCommand<CreateTenant>>
    {
        public CreateTenantValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("COMMAND ID equals Guid.Empty");

            this.RuleFor(x => x.Intent.Code).NotEmpty();
            this.RuleFor(x => x.Intent.AdminUserName).NotEmpty();
            this.RuleFor(x => x.Intent.AdminUserPassword).NotEmpty();
        }

        private bool BeAuthorized(Guid taskId)
        {
            return true;
        }
    }
}
