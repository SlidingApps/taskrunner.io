
using FluentValidation;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
	public interface IDomainEntityValidatorProvider
	{
		IValidator<TDomainEntity> CreateFor<TDomainEntity> () where TDomainEntity: IDomainEntity;
	}
}

