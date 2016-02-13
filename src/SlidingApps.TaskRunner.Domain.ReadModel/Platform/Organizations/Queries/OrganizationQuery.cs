
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries
{
    public class OrganizationQuery
        : IQuery<Organization>
    {
        public OrganizationQuery(Guid organizationId)
        {
            this.OrganizationId = organizationId;
        }

        public Guid OrganizationId { get; set; }
    }
}
