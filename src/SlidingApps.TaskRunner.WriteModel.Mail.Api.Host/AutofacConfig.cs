
using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Api.Host
{
	public class AutofacConfig
	{
		public static IContainer BuildContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Mail.Api.IAssemblyMarker).Assembly);
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Mail.Domain.AutofacModule).Assembly);

			return builder.Build();
		}
	}
}

