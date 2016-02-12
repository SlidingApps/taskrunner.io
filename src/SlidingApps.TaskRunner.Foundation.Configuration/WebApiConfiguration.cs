
using System.Configuration;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class WebApiConfiguration
    {
        public const string DEFAULT_HOST_URI_FORMAT = "http://{0}:{1}";

        public static string HostUri
        {
            get
            {
                string address = ConfigurationManager.AppSettings[AppSetting.HOST_ADDRESS];
                string port = ConfigurationManager.AppSettings[AppSetting.HOST_PORT];
                int _port = !string.IsNullOrEmpty(port) ? int.Parse(port) : 8000;

                return string.Format(WebApiConfiguration.DEFAULT_HOST_URI_FORMAT, address, _port);
            }
        }
    }
}
