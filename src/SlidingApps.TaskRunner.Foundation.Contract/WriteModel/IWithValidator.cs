
using FluentValidation.Results;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
    public interface IWithValidator<TDomainEntity> 
		: IDomainEntity 
		where TDomainEntity: IDomainEntity
	{
		ValidationResult Validate();
	}

}

