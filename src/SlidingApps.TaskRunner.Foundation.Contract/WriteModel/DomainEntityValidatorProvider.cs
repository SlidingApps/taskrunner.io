
using Autofac;
using FluentValidation;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
	public class DomainEntityValidatorProvider
        : IDomainEntityValidatorProvider 
	{
		private readonly IComponentContext context;

		public DomainEntityValidatorProvider(IComponentContext context)
		{
			this.context = context;
		}

		public IValidator<TDomainEntity> CreateFor<TDomainEntity>() 
			where TDomainEntity: IDomainEntity
		{  
			return this.context.Resolve<IValidator<TDomainEntity>>();
		}  
	}
}

