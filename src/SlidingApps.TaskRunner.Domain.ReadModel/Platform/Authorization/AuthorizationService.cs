
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization
{
    public class AuthorizationService :
        IQueryHandler<AccountCredentialsCollectionQuery, AccountCredentialsCollection>
    {
        private readonly IQueryProvider queryProvider;

        public AuthorizationService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public AccountCredentialsCollection Handle(AccountCredentialsCollectionQuery query)
        {
            var _query =
                this.queryProvider.From<AccountCredentials>()
                    .By(x => x.Username).EqualTo(query.Username)
                    .By(x => x.Password).EqualTo(query.Password);

            var credentials = _query.ToList();
            var collection = new AccountCredentialsCollection(credentials);

            return collection;
        }
    }
}
