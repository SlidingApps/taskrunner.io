
using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Bus.Host
{
    public class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(Domain.AutofacModule).Assembly);

            return builder.Build();
        }
    }
}