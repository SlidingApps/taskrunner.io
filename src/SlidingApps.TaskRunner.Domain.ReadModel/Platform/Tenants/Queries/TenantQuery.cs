
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Queries
{
    public class TenantQuery
        : IQuery<Tenant>
    {
        public TenantQuery(Guid organizationId)
        {
            this.OrganizationId = organizationId;
        }

        public Guid OrganizationId { get; set; }
    }
}
