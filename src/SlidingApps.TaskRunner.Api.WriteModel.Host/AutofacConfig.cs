﻿
using Autofac;

namespace SlidingApps.TaskRunner.Api.WriteModel.Host
{
	public class AutofacConfig
	{
		public static IContainer BuildContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(Api.WriteModel.AutofacModule).Assembly);
			builder.RegisterAssemblyModules(typeof(Domain.WriteModel.AutofacModule).Assembly);

			return builder.Build();
		}
	}
}

