
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.WriteModel.Platform
{
    [RoutePrefix("command/tenants"), ApiExceptionFilter]
    public class TenantController
        : ApiController
    {
        private readonly IBusConnector connector;

        public TenantController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreateTenant([FromBody] CreateTenant intent)
        {
            var command = new TenantCommand<CreateTenant>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
