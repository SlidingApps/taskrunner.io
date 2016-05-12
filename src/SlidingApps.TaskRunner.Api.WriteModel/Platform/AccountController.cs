
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.WriteModel.Platform
{
    [RoutePrefix("command/tenants/{tenantId:guid}/accounts"), ApiExceptionFilter]
    public class AccountController
        : ApiController
    {
        private readonly IBusConnector connector;

        public AccountController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreateAccount(Guid tenantId, [FromBody] CreateAccount intent)
        {
            var command = new AccountCommand<CreateAccount>(tenantId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/passwordlink")]
        public async Task<HttpResponseMessage> PostSendResetPasswordLink(Guid tenantId, string name, [FromBody] SendResetPasswordLink intent)
        {
            var command = new AccountCommand<SendResetPasswordLink>(tenantId, Guid.NewGuid(), intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{accountId:guid}/changename")]
        public async Task<HttpResponseMessage> PostChangeAccountProfileName(Guid tenantId, Guid personId, [FromBody] ChangeAccountProfileName intent)
        {
            var command = new AccountCommand<ChangeAccountProfileName>(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route("{accountId:guid}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangeAccountUserPeriod(Guid tenantId, Guid personId, [FromBody] ChangeAccountUserPeriod intent)
        {
            var command = new AccountCommand<ChangeAccountUserPeriod>(tenantId, personId, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
