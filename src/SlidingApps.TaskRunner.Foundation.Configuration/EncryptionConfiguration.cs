
namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class EncryptionConfiguration
    {
        public static string PasswordKey
        {
            get
            {
                string key = ApplicationConfiguration.Store[AppSetting.ENCRYPTION_PASSWORD_KEY];

                return key;
            }
        }

        public static string PasswordInitVector
        {
            get
            {
                string vector = ApplicationConfiguration.Store[AppSetting.ENCRYPTION_PASSWORD_INITVECTOR];

                return vector;
            }
        }

        public static string SymmetricKey
        {
            get
            {
                string key = ApplicationConfiguration.Store[AppSetting.ENCRYPTION_SYMMETRIC_KEY];

                return key;
            }
        }

        public static string SymmetricInitVector
        {
            get
            {
                string vector = ApplicationConfiguration.Store[AppSetting.ENCRYPTION_SYMMETRIC_INITVECTOR];

                return vector;
            }
        }
    }
}
