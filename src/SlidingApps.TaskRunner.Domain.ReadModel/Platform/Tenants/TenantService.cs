﻿
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants
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

            return resource != null ? new TenantCodeAvailability(false) : new TenantCodeAvailability(true);
        }
    }
}
