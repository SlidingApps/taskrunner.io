

using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations
{
    public interface IPersonFormatValues
        : IFormatValues
    {
        Guid OrganizationId { get; }

        Guid PersonId { get; }
    }
}
