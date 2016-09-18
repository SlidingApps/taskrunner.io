
using SlidingApps.TaskRunner.Foundation.ReadModel;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations
{
    public class DecryptedLink
     : DataRepresentation
    {
        public DecryptedLink()
        {
            this.templates.Add(new SelfLinkTemplate(DecryptedLink.SELF_LINK_TEMPLATE));
        }

        public DecryptedLink(string username, string link)
            : this()
        {
            this.Username = username;
            this.Link = link;
        }

        private const string SELF_LINK_TEMPLATE = "/accounts/{username}/decryption/{link}";

        public string Username { get; set; }

        public string Link { get; set; }
    }
}
