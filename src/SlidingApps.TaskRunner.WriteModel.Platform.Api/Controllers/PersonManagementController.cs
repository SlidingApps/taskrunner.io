
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents;
using SlidingApps.TaskRunner.Foundation.MessageBus;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Api.Controllers
{
    [RoutePrefix("command/accounts"), ApiExceptionFilter]
    public class PersonManagementController
        : ApiController
    {
        private readonly IBusConnector connector;

        public PersonManagementController(IBusConnector connector)
			: base()
	    {
            this.connector = connector;
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostCreateAccount([FromBody] CreateAccount intent)
        {
            var command = new PersonCommand<CreateAccount>(intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        //[HttpGet, Route(@"{code:regex([a-z0-9.%@])}/confirmation/{link}")]
        //public async Task<HttpResponseMessage> GetConfirmTenant(string code, [FromUri] string link)
        //{
        //    var intent = new ConfirmTenant(link);
        //    var command = new TenantCommand<ConfirmTenant>(code, intent);
        //    await this.connector.SendCommand(command);

        //    return ApiResponse.CommandResponse(command);
        //}

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/confirmationlink")]
        public async Task<HttpResponseMessage> PostSendConfirmationLink(string name)
        {
            var command = new PersonCommand<SendConfirmationLink>(new SendConfirmationLink { Name = name });
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/passwordlink")]
        public async Task<HttpResponseMessage> PostSendResetPasswordLink(string name)
        {
            var command = new PersonCommand<SendResetPasswordLink>(new SendResetPasswordLink { Name = name });
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/changename")]
        public async Task<HttpResponseMessage> PostChangeAccountProfileName(string name, [FromBody] ChangePersonIdentityName intent)
        {
            var command = new PersonCommand<ChangePersonIdentityName>(name, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }

        [HttpPost, Route(@"{name:regex([a-z0-9.%@])}/changeperiod")]
        public async Task<HttpResponseMessage> PostChangeAccountUserPeriod(string name, [FromBody] ChangePersonUserPeriod intent)
        {
            var command = new PersonCommand<ChangePersonUserPeriod>(name, intent);
            await this.connector.SendCommand(command);

            return ApiResponse.CommandResponse(command);
        }
    }
}
