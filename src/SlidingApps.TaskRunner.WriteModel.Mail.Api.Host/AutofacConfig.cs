
using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Api.Host
{
	public class AutofacConfig
	{
		public static IContainer BuildContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Communication.Api.IAssemblyMarker).Assembly);
            builder.RegisterAssemblyModules(typeof(TaskRunner.WriteModel.Communication.Domain.AutofacModule).Assembly);

			return builder.Build();
		}
	}
}

