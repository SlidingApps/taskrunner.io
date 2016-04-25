
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Representations
{
    public class AccountCredentialsCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        private AccountCredentialsCollection(int? page = null, int? pageSize = null)
            : base(page, pageSize)
        {
            this.templates.Add(new SelfLinkTemplate(AccountCredentialsCollection.SELF_LINK_TEMPLATE));
        }

        public AccountCredentialsCollection(IEnumerable<AccountCredentials> accountCredentials, int? page = null, int? pageSize = null)
            : this(page, pageSize)
        {
            this.AccountCredentials = accountCredentials;
        }

        [HalJsonEmbedded("accountcredentials")]
        public IEnumerable<AccountCredentials> AccountCredentials { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.AccountCredentials.ToList().ForEach(x => x.FormatLinks((new { }).ActLike<IAccountCredentialsFormatValues>()));
        }
    }
}
