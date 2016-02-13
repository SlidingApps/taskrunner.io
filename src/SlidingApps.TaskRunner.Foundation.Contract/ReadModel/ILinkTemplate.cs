
namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public interface ILinkTemplate
    {
        string Name { get; }

        int Order { get; }

        string Template { get; }

        string Formatter(string template, IFormatValues values);
    }
}