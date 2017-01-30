
using Autofac;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
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
            this.Map<Person>("TaskRunner", "Person_V");
            this.Map<PersonCredentials>("TaskRunner", "Person_Credentials_V");
            this.Map<PersonProfile>("TaskRunner", "Person_Identity_V");

            this.BuildMapping();
        }
    }
}
