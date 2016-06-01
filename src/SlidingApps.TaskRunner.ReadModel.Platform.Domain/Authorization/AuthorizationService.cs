
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Encryption;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization
{
    public class AuthorizationService :
        IQueryHandler<AccountValidityQuery, AccountValidity>
    {
        private readonly IQueryProvider queryProvider;

        public AuthorizationService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public AccountValidity Handle(AccountValidityQuery query)
        {
            var account =
                this.queryProvider.From<AccountCredentials>()
                    .By(x => x.Username).EqualTo(query.Username)
                    .By(x => x.ValidFrom).LessThanOrEqual(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    .By(x => x.validUntil).GreaterThanOrEqual(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    .SingleOrDefault();

            AccountValidity validity = new AccountValidity();
            validity.IsValid = false;

            if (account != null)
            {
                var cryptor = new BlowFish(Constant.PASSWORD_ENCRYPTION_KEY);
                cryptor.IV = Constant.PASSWORD_ENCRYPTION_INIT_VECTOR.ToBytes();
                var password = cryptor.Encrypt_CBC(string.Format(Constant.PASSWORD_SALTING_TEMPLATE, query.Password, account.Salt));

                validity.IsValid = account.Password == password;
                if (validity.IsValid)
                {
                    validity.Id = account.Id;
                    validity.EmailAddress = account.EmailAddress;
                    validity.Username = account.Username;
                }
            }

            return validity;
        }
    }
}
