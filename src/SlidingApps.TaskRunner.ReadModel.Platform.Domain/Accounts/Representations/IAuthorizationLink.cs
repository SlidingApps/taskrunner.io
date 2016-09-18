
namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations
{
    public interface IAuthorizationLink
    {
        string username { get; set; }

        string link { get; set; }
    }
}