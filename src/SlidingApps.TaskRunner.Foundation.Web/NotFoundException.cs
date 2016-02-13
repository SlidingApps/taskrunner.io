
using System;
using System.Net;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    public class NotFoundException 
        : Exception
    {
        public override string ToString()
        {
            return HttpStatusCode.NotFound.ToString();
        }
    }
}
