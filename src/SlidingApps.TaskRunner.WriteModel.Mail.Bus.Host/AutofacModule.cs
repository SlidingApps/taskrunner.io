
using Autofac;
using Autofac.Features.Variance;
using MassTransit;
using MassTransit.RabbitMqTransport.Contexts;
using MediatR;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.MassTransit;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using System.Collections.Generic;
using Module = Autofac.Module;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Bus.Host
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MassTransitConnector>().As<IBusConnector>();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof (IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterConsumers(typeof(IAssemblyMarker).Assembly);

            builder.RegisterType<RabbitMQConfigration>().As<RabbitMQConfigration>();

            builder.Register(context => MassTransit.Bus.Factory.CreateUsingRabbitMq(config =>
            {
                RabbitMQConfigration rabbitMQSettings = context.Resolve<RabbitMQConfigration>();

                config.ConfigureSend(send =>
                    send.UseSendExecute(se =>
                    {
                        var _se = se as RabbitMqSendContextImpl<DomainEventMessage<IDomainEvent>>;
                        if (_se != null)
                        {
                            _se.Headers.Set("type", _se.Message.Event.GetType().ToFriendlyName());
                
                        }
                    }));

                var host = config.Host(rabbitMQSettings.VirtualHostUri, h =>
                {
                    h.Username(ApplicationConfiguration.Store[Foundation.Configuration.AppSetting.RABBITMQ_USER]);
                    h.Password(ApplicationConfiguration.Store[Foundation.Configuration.AppSetting.RABBITMQ_PASSWORD]);
                });

                var durable = ApplicationConfiguration.Store[Foundation.Configuration.AppSetting.RABBITMQ_DURABLE_QUEUE];
                config.Durable = bool.Parse(durable);
                config.ReceiveEndpoint(host, ApplicationConfiguration.Store[Foundation.Configuration.AppSetting.RABBITMQ_QUEUE_COMMAND], 
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