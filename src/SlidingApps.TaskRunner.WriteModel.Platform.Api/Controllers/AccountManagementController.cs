
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Api.Controllers
{
    [RoutePrefix("command/accounts"), ApiExceptionFilter]
    public class AccountManagementController
        : ApiController
    {
        private readonly IBusConnector connector;

        public AccountManagementController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreateAccount([FromBody] CreateAccount intent)
        {
            var command = new AccountCommand<CreateAccount>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/passwordlink")]
        public async Task<HttpResponseMessage> PostSendResetPasswordLink(string name)
        {
            var command = new AccountCommand<SendResetPasswordLink>(new SendResetPasswordLink { Name = name });
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/changename")]
        public async Task<HttpResponseMessage> PostChangeAccountProfileName(string name, [FromBody] ChangeAccountProfileName intent)
        {
            var command = new AccountCommand<ChangeAccountProfileName>(name, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangeAccountUserPeriod(string name, [FromBody] ChangeAccountUserPeriod intent)
        {
            var command = new AccountCommand<ChangeAccountUserPeriod>(name, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
