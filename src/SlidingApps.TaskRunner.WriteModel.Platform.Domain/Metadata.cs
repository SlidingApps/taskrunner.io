
using SlidingApps.TaskRunner.Foundation.Configuration;
using System.Configuration;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain
{
    public static class Metadata
    {
        public static string SCHEMA_NAME = ApplicationConfiguration.Store[AppSetting.NHIBERNATE_SCHEMA] ?? string.Empty;
    }
}
