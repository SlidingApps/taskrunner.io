
namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations
{
    public interface IAuthorizationLink
    {
        string username { get; set; }

        string link { get; set; }
    }
}