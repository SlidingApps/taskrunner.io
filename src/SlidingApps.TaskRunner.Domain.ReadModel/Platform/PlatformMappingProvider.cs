
using Autofac;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform
{
    public class PlatformMappingProvider
        : MappingProvider
    {
        public PlatformMappingProvider(IComponentContext context, IApplicationConfigurationStore configuration)
            : base(context, configuration)
        {
            this.Schema("SlidingApps.TaskRunner");

            this.Map<Organization>("SlidingApps.TaskRunner", "Organization_V");
            this.Map<Person>("SlidingApps.TaskRunner", "Person_V");

            this.BuildMapping();
        }
    }
}
