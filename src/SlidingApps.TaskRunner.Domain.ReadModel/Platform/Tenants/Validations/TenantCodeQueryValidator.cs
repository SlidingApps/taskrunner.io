
using FluentValidation;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Queries;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Validations
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
