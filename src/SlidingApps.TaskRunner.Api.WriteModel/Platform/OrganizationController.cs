
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Commands;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.WriteModel.Platform
{
    [RoutePrefix("command/organizations"), ApiExceptionFilter]
    public class OrganizationController
        : ApiController
    {
        private readonly IBusConnector connector;

        public OrganizationController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreateOrganization([FromBody] V1.Platform.Organizations.CreateOrganization intent)
        {
            CreateOrganization command = new CreateOrganization(intent.Code, intent.Name, intent.Description, intent.ValidFrom, intent.ValidUntil);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
