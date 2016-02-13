
namespace SlidingApps.TaskRunner.Foundation.Dapper.Dialect
{
    public interface IDatabaseProviderFactory
    {
        IDatabaseProvider Resolve(string databaseType);
    }
}
