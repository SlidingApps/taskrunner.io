
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Queries
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
