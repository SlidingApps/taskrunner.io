
namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface ICommandMessage<out TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : ICommandResult
    {
        TCommand Command { get; }
    }
}
