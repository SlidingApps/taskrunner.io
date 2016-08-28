using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class SiteConfiguration
    {
        public static string BaseUrl
        {
            get
            {
                string address = ApplicationConfiguration.Store[AppSetting.SITE_ADDRESS];
                string port = ApplicationConfiguration.Store[AppSetting.SITE_PORT];
                int _port = !string.IsNullOrEmpty(port) ? int.Parse(port) : 8000;

                return string.Format(AppSetting.SITE_BASE_URI_TEMPLATE, address, _port);
            }
        }

        public static string ApplicationBaseUrl
        {
            get
            {
                return string.Format("{0}/#", SiteConfiguration.BaseUrl);
            }
        }
    }
}
