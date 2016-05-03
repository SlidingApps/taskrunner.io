
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Maps
{
    public class AccountProfileMap
        : AuditableDataEntityMap<Entities.AccountProfile, Guid>
    {
        private const string TABLE_NAME = "Account_Profile_S";

        public AccountProfileMap()
            : base(Metadata.SCHEMA_NAME, AccountProfileMap.TABLE_NAME)
        {
            this.Map(x => x.Name);
            this.Map(x => x.FirstName);
            this.Map(x => x.Info);
            this.Map(x => x.Status).CustomType<GenericEnumMapper<EntityStatus>>();
            this.Map(x => x.Link);

            this.References(x => x.Account).Unique().Column("AccountId");
        }
    }
}
