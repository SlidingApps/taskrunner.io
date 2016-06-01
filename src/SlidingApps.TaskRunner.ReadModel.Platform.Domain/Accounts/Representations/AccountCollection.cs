
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations
{
    public sealed class AccountCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants/{tenantId}/accounts?name={name}&page={page}&pageSize={pageSize}";

        private AccountCollection(int? page = null, int? pageSize = null)
            : base(page, pageSize)
        {
            this.templates.Add(new SelfLinkTemplate(AccountCollection.SELF_LINK_TEMPLATE));
            this.templates.Add(new PreviousLinkTemplate(AccountCollection.SELF_LINK_TEMPLATE));
        }

        public AccountCollection(IEnumerable<Account> persons, int? page = null, int? pageSize = null)
            : this(page, pageSize)
        {
            this.Accounts = persons;
        }

        [HalJsonEmbedded("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.Accounts.ToList().ForEach(x => x.FormatLinks((new { x.TenantId, AccountId = x.Id }).ActLike<IAccountFormatValues>()));
        }
    }
}
