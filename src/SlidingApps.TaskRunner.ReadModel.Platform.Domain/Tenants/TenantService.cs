
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants
{
    public class OrganizationService :
        IQueryHandler<TenantQuery, Tenant>,
        IQueryHandler<TenantCollectionQuery, TenantCollection>,
        IQueryHandler<TenantCodeQuery, TenantCodeAvailability>
    {
        private readonly IQueryProvider queryProvider;

        public OrganizationService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public TenantCollection Handle(TenantCollectionQuery query)
        {
            var _query = this.queryProvider.From<Tenant>();
            if (!string.IsNullOrEmpty(query.Code))
            {
                _query.By(x => x.Code).EqualTo(query.Code);
            }

            var collection = _query.OrderBy(x => x.Code).Limit(query.Page, query.PageSize).ToList<Tenant>();

            return new TenantCollection(collection);
        }

        public Tenant Handle(TenantQuery query)
        {
            var resource =
                this.queryProvider.From<Tenant>()
                    .By(x => x.Id).EqualTo(query.OrganizationId)
                    .SingleOrDefault();

            return resource;
        }

        public TenantCodeAvailability Handle(TenantCodeQuery query)
        {
            var resource =
                this.queryProvider.From<Tenant>()
                    .By(x => x.Code).EqualTo(query.Code)
                    .SingleOrDefault();

            var resourceId = resource != null ? resource.Id : Guid.Empty; 

            return resource != null ? new TenantCodeAvailability(resourceId, query.Code, false) : new TenantCodeAvailability(resourceId, query.Code, true);
        }
    }
}
