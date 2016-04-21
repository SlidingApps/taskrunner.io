
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries
{
    public class AccountQuery
        : IQuery<Account>
    {
        public AccountQuery(Guid tenantId, Guid personId)
        {
            this.TenantId = tenantId;
            this.PersonId = personId;
        }

        public Guid TenantId { get; set; }

        public Guid PersonId { get; set; }
    }
}
