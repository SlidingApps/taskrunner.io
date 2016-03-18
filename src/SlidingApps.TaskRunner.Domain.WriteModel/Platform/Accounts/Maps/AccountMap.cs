using SlidingApps.TaskRunner.Foundation.NHibernate;
using FluentNHibernate.Mapping;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Maps
{
    public class AccountMap
        : AuditableDataEntityMap<Entities.Account, Guid>
    {
        private const string TABLE_NAME = "Account_H";

        public AccountMap()
            : base(Metadata.SCHEMA_NAME, AccountMap.TABLE_NAME)
        {
            this.Map(x => x.EmailAddress);

            this.HasOne(x => x.Profile).Cascade.All().PropertyRef(x => x.Account).LazyLoad(Laziness.Proxy);
            this.HasOne(x => x.User).Cascade.All().PropertyRef(x => x.Account).LazyLoad(Laziness.Proxy);
        }
    }
}
