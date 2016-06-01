
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries
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
