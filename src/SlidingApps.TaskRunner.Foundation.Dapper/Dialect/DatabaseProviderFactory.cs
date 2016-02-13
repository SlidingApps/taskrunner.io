
using Autofac;
using System;

namespace SlidingApps.TaskRunner.Foundation.Dapper.Dialect
{
    public class DatabaseProviderFactory 
        : IDatabaseProviderFactory
    {
        private readonly IComponentContext context;

        public DatabaseProviderFactory(IComponentContext context)
        {
            this.context = context;
        }

        public IDatabaseProvider Resolve(string databaseType)
        {
            return this.context.ResolveKeyed<IDatabaseProvider>(databaseType);
        }
    }
}
