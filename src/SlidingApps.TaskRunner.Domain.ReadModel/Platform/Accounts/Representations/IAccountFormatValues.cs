

using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations
{
    public interface IAccountFormatValues
        : IFormatValues
    {
        Guid TenantId { get; }

        Guid AccountId { get; }
    }
}
