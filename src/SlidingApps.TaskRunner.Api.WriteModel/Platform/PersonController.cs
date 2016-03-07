
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
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
        public async Task<HttpResponseMessage> PostCreatePerson(Guid tenantId, [FromBody] V1.Platform.Persons.CreatePerson intent)
        {
            CreatePerson command = new CreatePerson(tenantId, intent.Name, intent.FirstName, intent.Info, intent.StartDate, intent.EndDate);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changename")]
        public async Task<HttpResponseMessage> PostChangePersonName(Guid tenantId, Guid personId, [FromBody] V1.Platform.Persons.ChangePersonName intent)
        {
            ChangePersonName command = new ChangePersonName(tenantId, personId, intent.Name, intent.FirstName);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangePersonPeriod(Guid tenantId, Guid personId, [FromBody] V1.Platform.Persons.ChangePersonPeriod intent)
        {
            ChangePersonPeriod command = new ChangePersonPeriod(tenantId, personId, intent.StartDate, intent.EndDate);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
