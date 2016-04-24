
using Autofac;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Representations;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform
{
    public class PlatformMappingProvider
        : MappingProvider
    {
        public PlatformMappingProvider(IComponentContext context)
            : base(context)
        {
            this.Schema("TaskRunner");

            this.Map<Tenant>("TaskRunner", "Tenant_V");
            this.Map<Account>("TaskRunner", "Account_V");
            this.Map<AccountCredentials>("TaskRunner", "Account_Credentials_V");

            this.BuildMapping();
        }
    }
}
