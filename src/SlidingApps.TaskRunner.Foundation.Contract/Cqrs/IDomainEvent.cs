
using MediatR;
using System;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IDomainEvent
        : IWithIdentifier<Guid>, IWithCorrelationIdentifier<Guid> { }
}
