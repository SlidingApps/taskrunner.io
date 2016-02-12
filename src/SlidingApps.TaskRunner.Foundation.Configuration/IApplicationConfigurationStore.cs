
namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public interface IApplicationConfigurationStore
    {
        string this[string key] { get; }
    }
}
