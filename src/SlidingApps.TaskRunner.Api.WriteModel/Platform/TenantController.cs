
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Commands;
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
        public async Task<HttpResponseMessage> PostCreateTenant([FromBody] V1.Platform.Tenants.CreateTenant intent)
        {
            CreateTenant command = new CreateTenant(intent.Code, intent.Name, intent.Description, intent.ValidFrom, intent.ValidUntil);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
