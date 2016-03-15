
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
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
        public async Task<HttpResponseMessage> PostCreatePerson(Guid tenantId, [FromBody] CreatePerson intent)
        {
            var command = new PersonCommand<CreatePerson>(tenantId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changename")]
        public async Task<HttpResponseMessage> PostChangePersonName(Guid tenantId, Guid personId, [FromBody] ChangePersonName intent)
        {
            var command = new PersonCommand<ChangePersonName>(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangePersonPeriod(Guid tenantId, Guid personId, [FromBody] ChangePersonPeriod intent)
        {
            var command = new PersonCommand<ChangePersonPeriod>(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
