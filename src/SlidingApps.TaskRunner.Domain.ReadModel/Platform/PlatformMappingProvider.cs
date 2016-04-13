
using Autofac;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Dapper;

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
            this.Map<Person>("TaskRunner", "Person_V");

            this.BuildMapping();
        }
    }
}
