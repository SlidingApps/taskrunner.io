
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Model.Intent;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Api.Controllers
{
    [RoutePrefix("command/mail"), ApiExceptionFilter]
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
