
using SlidingApps.TaskRunner.Foundation.Configuration;
using System.Configuration;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform
{
    public static class Metadata
    {
        public static string SCHEMA_NAME = ConfigurationManager.AppSettings[AppSetting.NHIBERNATE_SCHEMA] ?? string.Empty;
    }
}
