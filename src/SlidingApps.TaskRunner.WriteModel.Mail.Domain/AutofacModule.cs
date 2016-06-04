
using Autofac;
using Autofac.Core;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Decorator;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using FluentValidation;
using MassTransit;
using MediatR;
using NHibernate;
using System.Linq;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Foundation.NHibernate.UnitOfWork>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<DatabaseQueryProvider>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<SessionFactory>().InstancePerDependency();
            builder.Register(c => c.Resolve<SessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .As(t => t.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                    .Select(i =>
                        new KeyedService("request-handler-write", i)))
                .InstancePerDependency();

            builder.RegisterGenericDecorator(typeof(InternalDomainEventPublisherDecorator<,>), typeof(IRequestHandler<,>), "request-handler-write")
                .Keyed("request-with-internal-domain-event-publish-write", typeof(IRequestHandler<,>))
                .InstancePerDependency();

            builder.RegisterGenericDecorator(typeof(ValidationDecorator<,>), typeof(IRequestHandler<,>), "request-with-internal-domain-event-publish-write")
                .Keyed("request-pipeline-write" /* "request-with-validation-write" */, typeof(IRequestHandler<,>))
                .InstancePerDependency();

            //builder.RegisterGenericDecorator(typeof(UnitOfWorkDecorator<,>), typeof(IRequestHandler<,>), "request-with-validation-write")
            //    .Keyed("request-with-unit-of-work-write", typeof(IRequestHandler<,>))
            //    .InstancePerDependency();

            //builder.RegisterGenericDecorator(typeof(BusDomainEventPublisherDecorator<,>), typeof(IRequestHandler<,>), "request-with-validation-write")
            //    .Keyed("request-pipeline-write", typeof(IRequestHandler<,>))
            //    .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .As(t => t.GetInterfaces()
                .Where(i => i.IsClosedTypeOf(typeof(INotificationHandler<>)))
                .Select(i => i))
                .InstancePerDependency();

            builder.RegisterType<LocalDomainEventPublisher>()
                .Named<IDomainEventMessagePublisher>("local-domain-event-publisher")
                .InstancePerDependency();

            builder
                .Register(c => new BusDomainEventPublisher(c.Resolve<IBus>(), c.ResolveNamed<IDomainEventMessagePublisher>("local-domain-event-publisher")))
                .As<IDomainEventMessagePublisher>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .SingleInstance();

            builder.Register<IDomainEntityValidatorProvider>(ctx =>
            {
                IComponentContext c = ctx.Resolve<IComponentContext>();
                return new DomainEntityValidatorProvider(c);
            }).SingleInstance();

            //builder.RegisterDecorator<IDomainEventMessagePublisher>(
            //    (c, inner) =>
            //    {
            //        return new BusDomainEventPublisher(c.Resolve<IBus>(), inner);
            //    },
            //    "local-domain-event-publisher", "bus-domain-event-publisher")
            //    .InstancePerDependency();
        }
    }
}
