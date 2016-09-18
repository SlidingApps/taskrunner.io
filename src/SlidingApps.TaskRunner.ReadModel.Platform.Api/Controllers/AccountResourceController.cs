﻿
using MediatR;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Controllers
{
    [RoutePrefix("query/accounts"), ApiExceptionFilter]
    public class AccountResourceController
        : ApiController
    {
        private readonly IMediator mediator;

        public AccountResourceController(IMediator mediator)
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

        [HttpGet, Route("{username}/decryption/{link}")]
        public DecryptedLink GetDecryption(string username, string link)
        {
            LinkDecryptionQuery query = new LinkDecryptionQuery(username, link);
            var representations = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representations;
        }
    }
}
