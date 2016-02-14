
using Autofac;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using MassTransit;
using MassTransit.Log4NetIntegration;

namespace SlidingApps.TaskRunner.Api.WriteModel
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MassTransitConnector>().As<IBusConnector>();

            builder.RegisterType<ApplicationConfigurationStore>().As<IApplicationConfigurationStore>();
            builder.RegisterType<RabbitMQConfigration>().As<RabbitMQConfigration>();

            builder.Register(context => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                IApplicationConfigurationStore applicationConfiguration = context.Resolve<IApplicationConfigurationStore>();
                RabbitMQConfigration rabbitMQSettings = context.Resolve<RabbitMQConfigration>();

                config.UseLog4Net();
                config.UseJsonSerializer();

                var durable = applicationConfiguration[AppSetting.RABBITMQ_DURABLE_QUEUE];
                config.Durable = bool.Parse(durable);
                config.Host(rabbitMQSettings.VirtualHostUri, host =>
                {
                    host.Username(applicationConfiguration[AppSetting.RABBITMQ_USER]);
                    host.Password(applicationConfiguration[AppSetting.RABBITMQ_PASSWORD]);
                });
            }))
                .SingleInstance()
                .As<IBus>();
        }
    }
}
