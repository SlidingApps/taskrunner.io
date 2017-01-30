
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries
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
