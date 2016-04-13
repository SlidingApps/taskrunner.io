
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Tenants.Representations
{
    public interface ITenantFormatValues
        : IFormatValues
    {
        Guid TenantId { get; }
    }
}
