
namespace SlidingApps.TaskRunner.Foundation.Dapper.Filter
{
    public class PagingValues
    {
        public PagingValues(int page, int pageSize)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
