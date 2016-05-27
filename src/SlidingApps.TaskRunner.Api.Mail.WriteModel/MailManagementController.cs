
using SlidingApps.TaskRunner.Domain.Mail.WriteModel.Model;
using SlidingApps.TaskRunner.Domain.Mail.WriteModel.Model.Intent;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.Mail.WriteModel
{
    [RoutePrefix("command/v1/mail"), ApiExceptionFilter]
    public class MailManagementController
        : ApiController
    {
        private readonly IBusConnector connector;

        public MailManagementController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("passwordlink")]
        public async Task<HttpResponseMessage> PostSendResetPasswordLink([FromBody] SendResetPasswordLink intent)
        {
            var command = new MailCommand<SendResetPasswordLink>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
