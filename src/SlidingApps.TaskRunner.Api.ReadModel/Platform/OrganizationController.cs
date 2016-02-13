
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using MediatR;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.Api.ReadModel.Platform
{
    [RoutePrefix("query/organizations"), ApiExceptionFilter]
    public class OrganizationController
        : ApiController
    {
        private readonly IMediator mediator;

        public OrganizationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public OrganizationCollection GetOrganizationList([FromUri] string code = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            OrganizationCollectionQuery query = new OrganizationCollectionQuery(code, page, pageSize);
            var representations = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representations;
        }

        [HttpGet, Route("{organizationId:guid}")]
        public Organization GetOrganization(Guid organizationId)
        {
            OrganizationQuery query = new OrganizationQuery(organizationId);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }
    }
}
