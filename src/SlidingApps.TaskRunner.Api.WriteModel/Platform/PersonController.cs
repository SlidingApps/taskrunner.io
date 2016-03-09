
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.WriteModel.Platform
{
    [RoutePrefix("command/tenants/{tenantId:guid}/persons"), ApiExceptionFilter]
    public class PersonController
        : ApiController
    {
        private readonly IBusConnector connector;

        public PersonController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreatePerson(Guid tenantId, [FromBody] Domain.WriteModel.Platform.Persons.Intents.CreatePerson intent)
        {
            var command = new Domain.WriteModel.Platform.Persons.Commands.CreatePerson(tenantId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changename")]
        public async Task<HttpResponseMessage> PostChangePersonName(Guid tenantId, Guid personId, [FromBody] Domain.WriteModel.Platform.Persons.Intents.ChangePersonName intent)
        {
            var command = new Domain.WriteModel.Platform.Persons.Commands.ChangePersonName(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangePersonPeriod(Guid tenantId, Guid personId, [FromBody] Domain.WriteModel.Platform.Persons.Intents.ChangePersonPeriod intent)
        {
            var command = new Domain.WriteModel.Platform.Persons.Commands.ChangePersonPeriod(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
