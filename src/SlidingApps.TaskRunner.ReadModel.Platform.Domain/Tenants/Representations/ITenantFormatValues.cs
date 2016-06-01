
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations
{
    public interface ITenantFormatValues
        : IFormatValues
    {
        Guid TenantId { get; }
    }
}
