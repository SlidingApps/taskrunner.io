
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Queries
{
    public class CredentialsValidityQuery
        : IQuery<CredentialsValidity>
    {
        public CredentialsValidityQuery(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
