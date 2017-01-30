
using Newtonsoft.Json;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations
{
    public class PersonCredentials
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        private PersonCredentials()
        {
            this.templates.Add(new SelfLinkTemplate(PersonCredentials.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime validUntil { get; set; }

        [JsonIgnore]
        public Guid TenantId { get; set; }

        [JsonIgnore]
        public string TenantCode { get; set; }
    }
}
