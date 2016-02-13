
namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public interface IPagingFormatValues
        : IFormatValues
    {
        int Page { get; }

        int PageSize { get; }
    }
}
