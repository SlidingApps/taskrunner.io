
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using MediatR;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.ReadModel.Platform
{
    [RoutePrefix("query/organizations/{organizationId}/persons"), ApiExceptionFilter]
    public class PersonController
        : ApiController
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
			: base()
		{
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public PersonCollection GetPersonCollection(Guid organizationId, [FromUri] string name = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            PersonCollectionQuery query = new PersonCollectionQuery(organizationId, name, page, pageSize);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representation;
        }

        [HttpGet, Route("{personId:guid}")]
        public Person GetPerson(Guid organizationId, Guid personId)
        {
            PersonQuery query = new PersonQuery(organizationId, personId);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }
    }
}
