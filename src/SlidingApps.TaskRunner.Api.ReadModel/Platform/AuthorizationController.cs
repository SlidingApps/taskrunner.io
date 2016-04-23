
using MediatR;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
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
            return true;
        }
    }
}
