
using Autofac;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using MassTransit;
using MassTransit.Log4NetIntegration;
using MassTransit.RabbitMqTransport.Contexts;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using System;

namespace SlidingApps.TaskRunner.Api.WriteModel
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
                .As<IBus>();
        }
    }
}
