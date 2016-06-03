
using MediatR;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations;
using System.Web.Http;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Controllers
{
    [RoutePrefix("auth"), ApiExceptionFilter]
    public class AuthorizationController
        : ApiController
    {
        private readonly IMediator mediator;

        public AuthorizationController(IMediator mediator)
			: base()
		{
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public AccountValidity Verify()
        {
            if (this.Request.Headers.Authorization.Scheme != "Basic") throw new AuthorizationException(AuthorizationException.UNSUPPORTED_AUTHORIZATION_SCHEME);

            var header = this.Request.Headers.Authorization.Parameter.FromBase64();
            var _header = header.Split(':');

            if (_header.Length != 2) throw new AuthorizationException(AuthorizationException.INVALID_AUTHORIZATION_VALUE);

            string username = _header[0];
            string password = _header[1];

            AccountValidityQuery query = new AccountValidityQuery(username, password);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            if (!representation.IsValid) throw new AuthorizationException(AuthorizationException.INVALID_CREDENTIALS);

            return ApiResponse.Found(representation);
        }
    }
}
