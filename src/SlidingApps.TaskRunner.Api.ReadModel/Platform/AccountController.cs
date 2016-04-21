
using MediatR;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.ReadModel.Platform
{
    [RoutePrefix("query/tenants/{tenantId}/accounts"), ApiExceptionFilter]
    public class AccountController
        : ApiController
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
			: base()
		{
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public AccountCollection GetAccountCollection(Guid tenantId, [FromUri] string name = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            AccountCollectionQuery query = new AccountCollectionQuery(tenantId, name, page, pageSize);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representation;
        }

        [HttpGet, Route("{accountId:guid}")]
        public Account GetAccount(Guid tenantId, Guid accountId)
        {
            AccountQuery query = new AccountQuery(tenantId, accountId);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }
    }
}
