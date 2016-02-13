
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface ICommandResult
        : IList<IDomainEvent> { }
}
