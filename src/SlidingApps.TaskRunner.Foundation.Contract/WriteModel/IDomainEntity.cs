
namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
	public interface IDomainEntity 
	{
		object GetDataEnitity();
		void SetDataEnitity(object dataEntity);
	}

    public interface IDomainEntity<TDataEntity>
		: IDomainEntity
    {
		TDataEntity GetDataEntity();

        void SetDataEnitity(TDataEntity dataEntity);
    }
}
