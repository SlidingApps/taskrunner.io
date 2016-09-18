﻿
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts
{
    public class AccountService : 
        IQueryHandler<AccountCollectionQuery, AccountCollection>,
        IQueryHandler<AccountQuery, Account>,
        IQueryHandler<UserCredentialsQuery, Account>,
        IQueryHandler<LinkDecryptionQuery, DecryptedLink>
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

        public DecryptedLink Handle(LinkDecryptionQuery query)
        {
            var decoded =
                query.Link
                .FromBase58()
                .FromBytes()
                .Decrypt(EncryptionConfiguration.SymmetricKey, EncryptionConfiguration.SymmetricInitVector)
                .FromJson<object>()
                .ActLike<IAuthorizationLink>();

            var account =
                this.queryProvider.From<AccountProfile>()
                    .By(x => x.Link).EqualTo(decoded.link)
                    .SingleOrDefault();

            if (account == null)
            {
                throw new NotAuthorizedException("Invalid or expired link");
            }

            return new DecryptedLink(decoded.username, decoded.link);
        }
    }
}
