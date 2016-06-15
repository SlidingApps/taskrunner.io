
using System.Configuration;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    /// <summary>
    /// App.config configuration reader.
    /// </summary>
    public class ApplicationConfigurationStore
        : IApplicationConfigurationStore
    {
        /// <summary>
        /// Gets the app setting from the APP.CONFIG.
        /// </summary>
        /// <param name="key">The app setting key.</param>
        /// <returns></returns>
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
