
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Api.Controllers
{
    [RoutePrefix("command/tenants"), ApiExceptionFilter]
    public class TenantManagmentController
        : ApiController
    {
        private readonly IBusConnector connector;

        public TenantManagmentController(IBusConnector connector)
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

        [HttpPost, Route(@"{code:regex([a-z0-9.%@])}/changeinfo")]
        public async Task<HttpResponseMessage> PostChangeTenantInfo(string code, [FromBody] ChangeTenantInfo intent)
        {
            var command = new TenantCommand<ChangeTenantInfo>(code, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpGet, Route(@"{code:regex([a-z0-9.%@])}/confirmation/{link}")]
        public async Task<HttpResponseMessage> GetConfirmTenant(string code, [FromUri] string link)
        {
            var intent = new ConfirmTenant(link);
            var command = new TenantCommand<ConfirmTenant>(code, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
