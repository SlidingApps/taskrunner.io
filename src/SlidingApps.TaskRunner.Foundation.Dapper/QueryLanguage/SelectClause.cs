
namespace SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage
{
    public class SelectClause
        : IQueryLanguageClause
    {
        private const int CLAUSE_ORDER = 100;

        private const string CLAUSE_TEMPLATE = "SELECT {0}";

        public SelectClause(string fields)
        {
            this.Fields = fields;
        }

        public string Fields { get; private set; }

        public int Order
        {
            get { return CLAUSE_ORDER; }
        }

        public override string ToString()
        {
            string clause = string.Format(CLAUSE_TEMPLATE, this.Fields);

            return clause;
        }
    }
}
