
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Queries
{
    public class UserCredentialsQuery
        : IQuery<Account>
    {
        public UserCredentialsQuery(Guid tenantId, string name, string password)
        {
            this.TenantId = tenantId;
            this.Name = name;
            this.Password = password;
        }

        public Guid TenantId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
