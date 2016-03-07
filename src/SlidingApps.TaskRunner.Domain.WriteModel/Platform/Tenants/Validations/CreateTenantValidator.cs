﻿
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;
using FluentValidation;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Validations
{
    class CreateTenantValidator
        : AbstractValidator<CreateTenant>
    {
        public CreateTenantValidator()
        {
            this.RuleFor(c => c.Id).NotEmpty().WithMessage("COMMAND ID equals Guid.Empty");

            this.RuleFor(c => c.Code).NotEmpty().WithMessage("Code cannot be empty");
            this.RuleFor(c => c.Description).NotEmpty().WithMessage("Description cannot be empty");
        }

        private bool BeAuthorized(Guid taskId)
        {
            return true;
        }
    }
}
