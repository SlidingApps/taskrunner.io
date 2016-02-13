
namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public sealed class TableInfo
    {
        public TableInfo(string schemaName, string tableName)
        {
            this.SchemaName = schemaName;
            this.TableName = tableName;
        }

        public string SchemaName { get; private set; }

        public string TableName { get; private set; }
    }
}
