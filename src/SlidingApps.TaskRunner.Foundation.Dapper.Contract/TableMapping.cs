
namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public sealed class TableMapping
    {
        public TableMapping(SchemaMapping schemaMapping, string tableName)
        {
            this.Schema = schemaMapping;
            this.Table = tableName;
        }

        public SchemaMapping Schema { get; private set; }

        public string Table { get; private set; }

        public string GetSchemaAndTableName()
        {
            return string.Format("{0}.{1}", this.Schema.Redirect, this.Table);
        }
    }
}
