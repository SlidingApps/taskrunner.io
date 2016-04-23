
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Maps
{
    public class AccountUserMap
        : AuditableDataEntityMap<Entities.AccountUser, Guid>
    {
        private const string TABLE_NAME = "Account_User_S";

        public AccountUserMap()
            : base(Metadata.SCHEMA_NAME, AccountUserMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.Password);
            this.Map(x => x.Salt);
            this.Map(x => x.ValidUntil);

            this.References(x => x.Account).Unique().Column("AccountId");
        }
    }
}
