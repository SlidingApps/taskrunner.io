
namespace SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage
{
    public class FromClause
    : IQueryLanguageClause
    {
        private const int CLAUSE_ORDER = 200;

        private const string CLAUSE_TEMPLATE = "FROM {0}";

        public FromClause(string tableName)
        {
            this.TableName = tableName;
        }

        public string TableName { get; private set; }

        public int Order
        {
            get { return CLAUSE_ORDER; }
        }

        public override string ToString()
        {
            string clause = string.Format(CLAUSE_TEMPLATE, this.TableName);

            return clause;
        }
    }
}
