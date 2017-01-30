
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries
{
    public class UserCredentialsQuery
        : IQuery<Person>
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
