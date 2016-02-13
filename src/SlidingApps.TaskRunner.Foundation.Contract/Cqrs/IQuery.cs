

using SlidingApps.TaskRunner.Foundation.ReadModel;
using MediatR;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IQuery
        : IFormatValues { }

    public interface IQuery<out TResult>
        : IQuery, IRequest<TResult> where TResult : class { }
}