
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Queries
{
    public class LinkDecryptionQuery
        : IQuery<DecryptedLink>
    {
        public LinkDecryptionQuery(string username, string link)
        {
            this.Username = username;
            this.Link = link;
        }

        public string Username { get; set; }

        public string Link { get; set; }
    }
}
