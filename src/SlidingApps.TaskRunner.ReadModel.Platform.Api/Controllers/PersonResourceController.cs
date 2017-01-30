
using MediatR;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Controllers
{
    [RoutePrefix("query/accounts"), ApiExceptionFilter]
    public class PersonResourceController
        : ApiController
    {
        private readonly IMediator mediator;

        public PersonResourceController(IMediator mediator)
			: base()
		{
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public PersonCollection GetAccountCollection(Guid tenantId, [FromUri] string name = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            PersonCollectionQuery query = new PersonCollectionQuery(tenantId, name, page, pageSize);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representation;
        }

        [HttpGet, Route("{accountId:guid}")]
        public Person GetAccount(Guid tenantId, Guid accountId)
        {
            PersonQuery query = new PersonQuery(tenantId, accountId);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }

        [HttpGet, Route("{username}/decryptions/{link}")]
        public DecryptedLink GetDecryption(string username, string link)
        {
            LinkDecryptionQuery query = new LinkDecryptionQuery(username, link);
            var representations = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representations;
        }
    }
}
