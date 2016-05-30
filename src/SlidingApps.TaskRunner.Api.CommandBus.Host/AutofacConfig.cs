﻿using Autofac;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    public class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutofacModule>();
            builder.RegisterAssemblyModules(typeof(WriteModel.Platform.Domain.AutofacModule).Assembly);

            return builder.Build();
        }
    }
}