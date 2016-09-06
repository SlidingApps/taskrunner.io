

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class MailServiceConfiguration
    {
        public static string Domain
        {
            get
            {
                string domain = ApplicationConfiguration.Store[AppSetting.MAIL_SERVICE_DOMAIN];

                return domain;
            }
        }

        public static string NoreplyAddress
        {
            get
            {
                string address = ApplicationConfiguration.Store[AppSetting.MAIL_SERVICE_NO_REPLY_ADDRESS];

                return address;
            }
        }

        public static string SandboxAddress
        {
            get
            {
                string address = ApplicationConfiguration.Store[AppSetting.MAIL_SERVICE_SANDBOX_ADDRESS];

                return address;
            }
        }
    }
}
