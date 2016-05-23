
using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using MassTransit;
using MassTransit.Log4NetIntegration;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Api.WriteModel.Host
{
    public class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterApiControllers(typeof(WriteModel.AutofacModule).Assembly);
            builder.RegisterAssemblyTypes(typeof (IMediator).Assembly).AsImplementedInterfaces();

            builder.RegisterType<MassTransitConnector>().As<IBusConnector>();

            builder.RegisterType<RabbitMQConfigration>().As<RabbitMQConfigration>();

            builder.Register(context => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                RabbitMQConfigration rabbitMQSettings = context.Resolve<RabbitMQConfigration>();

                config.ConfigureSend(send =>
                    send.UseSendExecute(se =>
                    {
                        se.Headers.Set("type", ((Type)((dynamic)se).Message.Command.GetType()).ToFriendlyName());
                    }));

                config.UseLog4Net();
                config.UseJsonSerializer();

                var durable = ApplicationConfiguration.Store[AppSetting.RABBITMQ_DURABLE_QUEUE];
                config.Durable = bool.Parse(durable);
                config.Host(rabbitMQSettings.VirtualHostUri, host =>
                {
                    host.Username(ApplicationConfiguration.Store[AppSetting.RABBITMQ_USER]);
                    host.Password(ApplicationConfiguration.Store[AppSetting.RABBITMQ_PASSWORD]);
                });
            }))
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();

            builder.Register<SingleInstanceFactory>(ctx =>
				{
					var c = ctx.Resolve<IComponentContext>();
					return t =>
					{
					    object instance = c.IsRegisteredWithKey("request-pipeline-write", t) ? c.ResolveKeyed("request-pipeline-write", t) : c.Resolve(t);

					    return instance;
					};
				});

			builder.Register<MultiInstanceFactory>(context =>
				{
					var c = context.Resolve<IComponentContext>();
					return t => (IEnumerable<object>) c.Resolve(typeof (IEnumerable<>).MakeGenericType(t));
				});
		}
	}
}

