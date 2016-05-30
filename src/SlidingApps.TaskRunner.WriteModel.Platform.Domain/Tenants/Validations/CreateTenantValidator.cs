
using FluentValidation;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Validations
{
    class CreateTenantValidator
        : AbstractValidator<TenantCommand<CreateTenant>>
    {
        public CreateTenantValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("COMMAND ID equals Guid.Empty");

            this.RuleFor(x => x.Intent.Code).NotEmpty();
            this.RuleFor(x => x.Intent.UserName).NotEmpty();
            this.RuleFor(x => x.Intent.UserPassword).NotEmpty();
        }

        private bool BeAuthorized(Guid taskId)
        {
            return true;
        }
    }
}
