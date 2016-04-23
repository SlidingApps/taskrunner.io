
using ImpromptuInterface;
using Newtonsoft.Json;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Accounts.Representations
{
    public sealed class Account
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants/{tenantId}/accounts/{accountId}";

        private Account()
        {
            this.templates.Add(new SelfLinkTemplate(Account.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public string DisplayName { get; set; }

        public string Info { get; set; }

        public string EmailAddress { get; set; }

        public string UserName { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        [JsonIgnore]
        public Guid TenantId { get; set; }

        [JsonIgnore]
        public string TenantCode { get; set; }

        public override void FormatLinks(IFormatValues values)
        {
            base.FormatLinks((new { this.TenantId, AccountId = this.Id }).ActLike<IAccountFormatValues>());
        }
    }
}
