
using System.Web.Http;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    [RoutePrefix("$health")]
    public class HealthController
        : ApiController
    {
        [HttpGet, Route("")]
        public bool Get()
        {
            return true;
        }
    }
}
