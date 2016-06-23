
using System.Web.Http;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    [RoutePrefix("$health")]
    public class ServiceHealthController
        : ApiController
    {
        [HttpGet, Route("")]
        public bool Get()
        {
            return true;
        }
    }
}
