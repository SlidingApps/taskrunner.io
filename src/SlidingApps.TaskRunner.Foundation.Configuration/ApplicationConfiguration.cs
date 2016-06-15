
namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class ApplicationConfiguration
    {
        static ApplicationConfiguration()
        {
            ApplicationConfiguration.Store = new ApplicationConfigurationStore();

        }

        public static IApplicationConfigurationStore Store { get; private set; }
    }
}
