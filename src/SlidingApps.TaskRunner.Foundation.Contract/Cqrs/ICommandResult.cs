
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface ICommandResult
        : IEnumerable<IDomainEvent> { }
}
