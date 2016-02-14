
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.WriteModel.Platform
{
    [RoutePrefix("command/organizations/{organizationId:guid}/persons"), ApiExceptionFilter]
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
        public async Task<HttpResponseMessage> PostCreatePerson(Guid organizationId, [FromBody] V1.Platform.Persons.CreatePerson intent)
        {
            CreatePerson command = new CreatePerson(organizationId, intent.Name, intent.FirstName, intent.Info, intent.StartDate, intent.EndDate);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changename")]
        public async Task<HttpResponseMessage> PostChangePersonName(Guid organizationId, Guid personId, [FromBody] V1.Platform.Persons.ChangePersonName intent)
        {
            ChangePersonName command = new ChangePersonName(organizationId, personId, intent.Name, intent.FirstName);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{personId:guid}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangePersonPeriod(Guid organizationId, Guid personId, [FromBody] V1.Platform.Persons.ChangePersonPeriod intent)
        {
            ChangePersonPeriod command = new ChangePersonPeriod(organizationId, personId, intent.StartDate, intent.EndDate);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
