
namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class ApplicationConfiguration
    {
        static ApplicationConfiguration()
        {
            ApplicationConfiguration.Store = new ApplicationConfigurationStore_ORIG();

        }

        public static IApplicationConfigurationStore_ORIG Store { get; private set; }
    }
}
