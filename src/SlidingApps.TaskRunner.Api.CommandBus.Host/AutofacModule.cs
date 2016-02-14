
using Autofac;
using Autofac.Features.Variance;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using MassTransit;
using MediatR;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MassTransitConnector>().As<IBusConnector>();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof (IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterConsumers(Assembly.GetExecutingAssembly());

            builder.Register(context => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                IApplicationConfigurationStore applicationConfiguration = context.Resolve<IApplicationConfigurationStore>();
                RabbitMQConfigration rabbitMQSettings = context.Resolve<RabbitMQConfigration>();

                var host = config.Host(rabbitMQSettings.VirtualHostUri, h =>
                {
                    h.Username(applicationConfiguration[Foundation.Configuration.AppSetting.RABBITMQ_USER]);
                    h.Password(applicationConfiguration[Foundation.Configuration.AppSetting.RABBITMQ_PASSWORD]);
                });

                var durable = applicationConfiguration[Foundation.Configuration.AppSetting.RABBITMQ_DURABLE_QUEUE];
                config.Durable = bool.Parse(durable);
                config.ReceiveEndpoint(host, applicationConfiguration[Foundation.Configuration.AppSetting.RABBITMQ_QUEUE_COMMAND], 
                    epc => {
                        epc.Durable = bool.Parse(durable);
                        epc.LoadFrom(context);
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
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}