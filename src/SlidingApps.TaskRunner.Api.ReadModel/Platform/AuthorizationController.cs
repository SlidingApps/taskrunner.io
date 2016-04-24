
using MediatR;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Queries;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.ReadModel.Platform
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
        public bool Verify()
        {
            var header = this.Request.Headers.Authorization.Parameter.FromBase64();
            var _header = header.Split(':');

            string username = _header[0];
            string password = _header[1];

            AccountCredentialsCollectionQuery query = new AccountCredentialsCollectionQuery(username, password);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return true;
        }
    }
}
