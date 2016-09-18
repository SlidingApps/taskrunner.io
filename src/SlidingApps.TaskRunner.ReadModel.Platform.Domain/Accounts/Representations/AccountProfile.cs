
using Newtonsoft.Json;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts.Representations
{
    public class AccountProfile
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        private AccountProfile()
        {
            this.templates.Add(new SelfLinkTemplate(AccountProfile.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Status { get; set; }

        [JsonIgnore]
        public string Link { get; set; }

        [JsonIgnore]
        public Guid TenantId { get; set; }

        [JsonIgnore]
        public string TenantCode { get; set; }
    }
}
