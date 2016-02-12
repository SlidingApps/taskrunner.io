
using System.Configuration;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public class ApplicationConfigurationStore
        : IApplicationConfigurationStore
    {
        public string this[string key]
        {
            get
            {
                return this.GetSetting(key);
            }
        }

        private string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
