
namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
    public interface IDataEntity { }

    public interface IDataEntity<TIdentifier>
        : IDataEntity, IIdentifiable<TIdentifier> { }
}
