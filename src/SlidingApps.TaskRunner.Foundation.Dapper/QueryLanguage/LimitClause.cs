
namespace SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage
{
    public class LimitClause
        : IQueryLanguageClause
    {
        private const int CLAUSE_ORDER = 500;

        private const string CLAUSE_TEMPLATE = "LIMIT {0}, {1}";

        public LimitClause(int page, int pageSize)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }

        public int Order
        {
            get { return CLAUSE_ORDER; }
        }

        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public override string ToString()
        {
            string clause = string.Empty;

            if (this.Page > 0)
            {
                int offset = (this.Page - 1) * this.PageSize;
                clause = string.Format(CLAUSE_TEMPLATE, offset, this.PageSize);
            }

            return clause;
        }
    }
}
