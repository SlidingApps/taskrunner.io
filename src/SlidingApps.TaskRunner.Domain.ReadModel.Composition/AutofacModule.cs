
using Autofac;
using Autofac.Core;
using FluentValidation;
using MediatR;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.Foundation.Dapper.Dialect;
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;
using SlidingApps.TaskRunner.Foundation.Decorator;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Composition
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IAssemblyMarker).Assembly)
                .As(t => t.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                    .Select(i =>
                        new KeyedService("request-handler-read", i)))
                .InstancePerDependency();

            //builder.RegisterGenericDecorator(typeof(UnitOfWorkDecorator<,>), typeof(IRequestHandler<,>), "request-handler")
            //    .Keyed("request-with-unit-of-work", typeof(IRequestHandler<,>))
            //    .InstancePerDependency();

            builder.RegisterGenericDecorator(typeof(ValidationDecorator<,>), typeof(IRequestHandler<,>), "request-handler-read")
                .Keyed("request-pipeline-read", typeof(IRequestHandler<,>))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .SingleInstance();

            builder.RegisterType<Criteria>().As<ICriteria>().InstancePerDependency();
            builder.RegisterType<Criterion>().As<ICriterion>().InstancePerDependency();

            builder.Register<Foundation.Dapper.IQueryProvider>(ctx =>
            {
                IComponentContext c = ctx.Resolve<IComponentContext>();
                IMappingProvider m = ctx.Resolve<IMappingProvider>();
                IDatabaseProviderFactory d = ctx.Resolve<IDatabaseProviderFactory>();
                return new QueryProvider(c, m, d);
            }).InstancePerLifetimeScope();

            builder.RegisterType<SchemaMapping>().InstancePerLifetimeScope();

            builder.RegisterType<PlatformMappingProvider>().As<IMappingProvider>().SingleInstance();
            builder.RegisterType<DatabaseProviderFactory>().As<IDatabaseProviderFactory>().SingleInstance();
            builder.RegisterType<MySqlDatabaseProvider>().Keyed<IDatabaseProvider>("MySql.Data.MySqlClient").InstancePerDependency();

            builder.RegisterGeneric(typeof(Criteria<>)).As(typeof(ICriteria<>)).InstancePerDependency();
            builder.Register<CriteriaFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (ICriteria)c.Resolve(typeof(ICriteria<>).MakeGenericType(t));
            }).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Criterion<>)).As(typeof(ICriterion<>)).InstancePerDependency();
            builder.Register<CriterionFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (ICriterion)c.Resolve(typeof(ICriterion<>).MakeGenericType(t));
            }).InstancePerLifetimeScope();
        }
    }
}
