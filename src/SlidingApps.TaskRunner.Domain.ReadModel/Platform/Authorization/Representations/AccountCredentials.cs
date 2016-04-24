
using Newtonsoft.Json;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Representations
{
    public class AccountCredentials
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/";

        private AccountCredentials()
        {
            this.templates.Add(new SelfLinkTemplate(AccountCredentials.SELF_LINK_TEMPLATE));
        }

        public string Username { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public Guid TenantId { get; set; }

        [JsonIgnore]
        public string TenantCode { get; set; }
    }
}
