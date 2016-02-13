
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;

namespace SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage
{
    public class WhereClause
        : IQueryLanguageClause
    {
        private const int CLAUSE_ORDER = 300;

        private const string CLAUSE_TEMPLATE = "WHERE {0}";

        public WhereClause(ICriteria criteria)
        {
            this.Criteria = criteria;
        }

        public ICriteria Criteria { get; private set; }

        public int Order
        {
            get { return CLAUSE_ORDER; }
        }

        public override string ToString()
        {
            var criteria = this.Criteria.ToString();
            string clause = !string.IsNullOrEmpty(criteria) ? string.Format(CLAUSE_TEMPLATE, criteria) : string.Empty;

            return clause;
        }
    }
}
