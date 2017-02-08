using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Bus.Host
{
    public class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(WriteModel.Communication.Domain.AutofacModule).Assembly);

            return builder.Build();
        }
    }
}