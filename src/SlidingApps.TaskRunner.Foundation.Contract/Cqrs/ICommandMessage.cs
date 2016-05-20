
namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface ICommandMessage { }

    public interface ICommandMessage<out TCommand, TResult>
        : ICommandMessage
        where TCommand : ICommand<TResult>
        where TResult : ICommandResult
    {
        TCommand Command { get; }
    }
}
