
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations
{
    public class OrganizationService :
        IQueryHandler<OrganizationQuery, Organization>,
        IQueryHandler<OrganizationCollectionQuery, OrganizationCollection>,
        IQueryHandler<OrganizationCodeQuery, Organization>
    {
        private readonly IQueryProvider queryProvider;

        public OrganizationService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public OrganizationCollection Handle(OrganizationCollectionQuery query)
        {
            var _query = this.queryProvider.From<Organization>();
            if (!string.IsNullOrEmpty(query.Code))
            {
                _query.By(x => x.Code).EqualTo(query.Code);
            }

            var collection = _query.OrderBy(x => x.Code).Limit(query.Page, query.PageSize).ToList<Organization>();

            return new OrganizationCollection(collection);
        }

        public Organization Handle(OrganizationQuery query)
        {
            var resource =
                this.queryProvider.From<Organization>()
                    .By(x => x.Id).EqualTo(query.OrganizationId)
                    .SingleOrDefault();

            return resource;
        }

        public Organization Handle(OrganizationCodeQuery query)
        {
            var resource =
                this.queryProvider.From<Organization>()
                    .By(x => x.Code).EqualTo(query.Code)
                    .SingleOrDefault();

            return resource;
        }
    }
}
