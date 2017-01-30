
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations
{
    public interface IPersonFormatValues
        : IFormatValues
    {
        Guid TenantId { get; }

        Guid AccountId { get; }
    }
}
