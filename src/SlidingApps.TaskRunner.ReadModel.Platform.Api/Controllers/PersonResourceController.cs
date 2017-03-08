
using MediatR;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Controllers
{
    [RoutePrefix("query/persons"), ApiExceptionFilter]
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
        public PersonCollection GetPersonCollection([FromUri] string name = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            PersonCollectionQuery query = new PersonCollectionQuery(name, page, pageSize);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representation;
        }

        [HttpGet, Route(@"{username:regex([a-z0-9.%@])}")]
        public Person GetPerson(string username)
        {
            PersonQuery query = new PersonQuery(username);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }

        [HttpGet, Route(@"{username:regex([a-z0-9.%@])}/decryptions/{link}")]
        public DecryptedLink GetDecryption(string username, string link)
        {
            LinkDecryptionQuery query = new LinkDecryptionQuery(username, link);
            var representations = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representations;
        }
    }
}
