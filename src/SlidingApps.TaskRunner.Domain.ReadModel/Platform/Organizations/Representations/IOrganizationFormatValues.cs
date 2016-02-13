

using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations
{
    public interface IOrganizationFormatValues
        : IFormatValues
    {
        Guid OrganizationId { get; }
    }
}
