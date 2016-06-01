
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations
{
    public interface IAccountFormatValues
        : IFormatValues
    {
        Guid TenantId { get; }

        Guid AccountId { get; }
    }
}
