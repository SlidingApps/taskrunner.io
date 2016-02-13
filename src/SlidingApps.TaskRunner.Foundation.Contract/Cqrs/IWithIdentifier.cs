
namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IWithIdentifier<out TIdentifier>
    {
        TIdentifier Id { get; }
    }
}
