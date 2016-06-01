
using Autofac;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain
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
