
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts
{
    public class AccountService : 
        IQueryHandler<AccountCollectionQuery, AccountCollection>,
        IQueryHandler<AccountQuery, Account>,
        IQueryHandler<UserCredentialsQuery, Account>
    {
        private readonly IQueryProvider queryProvider;

        public AccountService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public AccountCollection Handle(AccountCollectionQuery query)
        {
            var _query = this.queryProvider.From<Account>().By(x => x.TenantId).EqualTo(query.TenantId);

            // Add 'like' criterium.
            if (!string.IsNullOrEmpty(query.Name))
            {
                _query.By(x => x.DisplayName).Like(query.Name);
            }

            _query.OrderBy(x => x.DisplayName).Limit(query.Page, query.PageSize);

            var persons = _query.ToList();
            var collection = new AccountCollection(persons, query.Page, query.PageSize);

            return collection;
        }

        public Account Handle(AccountQuery query)
        {
            var person =
                this.queryProvider.From<Account>()
                    .By(x => x.TenantId).EqualTo(query.TenantId)
                    .By(x => x.Id).EqualTo(query.PersonId)
                    .SingleOrDefault();

            return person;
        }

        public Account Handle(UserCredentialsQuery query)
        {
            var person =
                this.queryProvider.From<Account>()
                    .By(x => x.TenantId).EqualTo(query.TenantId)
                    .By(x => x.UserName).EqualTo(query.Name)
                    .By(x => x.UserName).EqualTo(query.Password)
                    .SingleOrDefault();

            return person;
        }
    }
}
