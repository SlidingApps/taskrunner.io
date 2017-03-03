
using Autofac;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Host
{
	public class AutofacConfig
	{
		public static IContainer BuildContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(IAssemblyMarker).Assembly);
            builder.RegisterAssemblyModules(typeof(Infrastructure.Domain.AutofacModule).Assembly);

			return builder.Build();
		}
	}
}

