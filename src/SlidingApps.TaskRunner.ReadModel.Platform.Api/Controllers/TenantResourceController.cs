
using MediatR;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Web;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;
using System;
using System.Web.Http;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Controllers
{
    [RoutePrefix("query/tenants"), ApiExceptionFilter]
    public class TenantResourceController
        : ApiController
    {
        private readonly IMediator mediator;

        public TenantResourceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet, Route("")]
        public TenantCollection GetTenantList([FromUri] string code = null, [FromUri] int page = 1, [FromUri] int pageSize = 50)
        {
            TenantCollectionQuery query = new TenantCollectionQuery(code, page, pageSize);
            var representations = this.mediator.Send(query).FormatHalJsonLinks(query);

            return representations;
        }

        [HttpGet, Route("{organizationId:guid}")]
        public Tenant GetTenant(Guid organizationId)
        {
            TenantQuery query = new TenantQuery(organizationId);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }

        [HttpGet, Route(@"{code:regex([a-z\d])}/availability")]
        public TenantCodeAvailability GetTenantCodeAvailability([FromUri]string code)
        {
            TenantCodeQuery query = new TenantCodeQuery(code);
            var representation = this.mediator.Send(query).FormatHalJsonLinks(query);

            return ApiResponse.Found(representation);
        }
    }
}
