
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Api.Controllers
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

        [HttpPost, Route("tenantconfirmation")]
        public async Task<HttpResponseMessage> PostSendTenantConfirmationLink([FromBody] SendTenantConfirmationLink intent)
        {
            var command = new MailCommand<SendTenantConfirmationLink>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("accountconfirmation")]
        public async Task<HttpResponseMessage> PostSendAccountConfirmationLink([FromBody] SendAccountConfirmationLink intent)
        {
            var command = new MailCommand<SendAccountConfirmationLink>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
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
