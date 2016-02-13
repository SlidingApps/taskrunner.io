
using Autofac;
using SlidingApps.TaskRunner.Foundation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public abstract class MappingProvider
        : IMappingProvider
    {
        private static readonly Dictionary<string, SchemaMapping> SCHEMA_CONFIG = new Dictionary<string, SchemaMapping>();

        private static readonly Dictionary<Type, TableInfo> TABLE_CONFIG = new Dictionary<Type, TableInfo>();

        private static readonly Dictionary<Type, TableMapping> MAPPINGS = new Dictionary<Type, TableMapping>();

        private readonly IComponentContext context;

        private readonly IApplicationConfigurationStore configuration;

        public MappingProvider(IComponentContext context, IApplicationConfigurationStore configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        protected void Schema(string schemaName)
        {
            var schema = this.context.Resolve<SchemaMapping>() as SchemaMapping;
            schema.Configure(schemaName);

            MappingProvider.SCHEMA_CONFIG[schemaName] = schema;
        }

        protected void Map<TType>(string schemName, string tableName)
        {
            MappingProvider.TABLE_CONFIG[typeof(TType)] = new TableInfo(schemName, tableName);
        }

        public TableMapping GetMapping<TEntity>()
        {
            return MappingProvider.MAPPINGS[typeof(TEntity)];
        }

        public void BuildMapping()
        {
            MappingProvider.TABLE_CONFIG.Keys.ToList()
                .ForEach(key =>
                {
                    var schemName = MappingProvider.TABLE_CONFIG[key].SchemaName;
                    var schema = MappingProvider.SCHEMA_CONFIG[schemName];
                    var table = MappingProvider.TABLE_CONFIG[key].TableName;

                    MappingProvider.MAPPINGS[key] = new TableMapping(schema, table);
                });
        }
    }
}
