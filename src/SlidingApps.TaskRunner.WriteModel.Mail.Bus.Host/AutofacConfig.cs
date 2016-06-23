using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Bus.Host
{
    public class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(WriteModel.Mail.Domain.AutofacModule).Assembly);

            return builder.Build();
        }
    }
}