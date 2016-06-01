
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries
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
