
using SlidingApps.TaskRunner.Foundation.Configuration;
using System.Configuration;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public sealed class SchemaMapping
    {
        private readonly IApplicationConfigurationStore configuration;

        public SchemaMapping(IApplicationConfigurationStore configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(string name)
        {
            this.Name = name;
            this.Redirect = this.configuration[string.Format(AppSetting.DAPPER_SCHEMA_REDIRECT_TEMPLATE, name.ToLower())] ?? name;
            this.ProviderName = this.configuration[string.Format(AppSetting.DAPPER_SCHEMA_PROVIDER_TEMPLATE, name.ToLower())] ?? (this.configuration[AppSetting.DAPPER_DEFAULT_PROVIDER] ?? "MySql.Data.MySqlClient");
            this.Connectionstring = this.configuration[string.Format(AppSetting.DAPPER_DEFAULT_CONNECTIONSTRING, name.ToLower())] ?? (this.configuration[AppSetting.DAPPER_DEFAULT_CONNECTIONSTRING] ?? string.Empty);
        }

        public string Name { get; private set; }

        public string Redirect { get; private set; }

        public string ProviderName { get; private set; }

        public string Connectionstring { get; private set; }
    }
}
