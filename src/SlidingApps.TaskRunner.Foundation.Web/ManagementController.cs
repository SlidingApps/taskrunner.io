
using System.Web.Http;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    [RoutePrefix("$management")]
    public class ManagementController
        : ApiController
    {
        [HttpGet, Route("")]
        public bool Get()
        {
            return true;
        }
    }
}
