
using FluentValidation;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Validations
{
    public class TenantCodeQueryValidator
        : AbstractValidator<TenantCodeQuery>
    {
        public TenantCodeQueryValidator()
        {
            RuleFor(c => c.Code).NotEmpty();
        }
    }
}
