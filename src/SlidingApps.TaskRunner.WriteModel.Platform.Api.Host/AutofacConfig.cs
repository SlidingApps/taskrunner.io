
using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Api.Host
{
	public class AutofacConfig
	{
		public static IContainer BuildContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Platform.Api.IAssemblyMarker).Assembly);
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Platform.Domain.AutofacModule).Assembly);

			return builder.Build();
		}
	}
}

