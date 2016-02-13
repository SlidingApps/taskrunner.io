
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    /// <summary>
    /// Enables CORS by adding 'Access-Control-Allow-Origin' to the HTTP response header.
    /// </summary>
    public class CorsMessageHandler
        : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var _request = await request.Content.ReadAsByteArrayAsync();
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                response.Headers.Add("Access-Control-Allow-Origin", "*");

                return response;
            }
            catch
            {
                HttpResponseMessage response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());

                return response;
            }
        }
    }
}
