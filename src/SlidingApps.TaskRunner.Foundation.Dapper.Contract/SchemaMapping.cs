
using SlidingApps.TaskRunner.Foundation.Configuration;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public sealed class SchemaMapping
    {
        public void Configure(string name)
        {
            this.Name = name;
            this.Redirect = ApplicationConfiguration.Store[string.Format(AppSetting.DAPPER_SCHEMA_REDIRECT_TEMPLATE, name.ToLower())] ?? name;
            this.ProviderName = ApplicationConfiguration.Store[string.Format(AppSetting.DAPPER_SCHEMA_PROVIDER_TEMPLATE, name.ToLower())] ?? (ApplicationConfiguration.Store[AppSetting.DAPPER_DEFAULT_PROVIDER] ?? "MySql.Data.MySqlClient");
            this.Connectionstring = ApplicationConfiguration.Store[string.Format(AppSetting.DAPPER_DEFAULT_CONNECTIONSTRING, name.ToLower())] ?? (ApplicationConfiguration.Store[AppSetting.DAPPER_DEFAULT_CONNECTIONSTRING] ?? string.Empty);
        }

        public string Name { get; private set; }

        public string Redirect { get; private set; }

        public string ProviderName { get; private set; }

        public string Connectionstring { get; private set; }
    }
}
