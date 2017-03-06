
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations
{
    public class CredentialsValidity
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        public CredentialsValidity()
        {
            this.templates.Add(new SelfLinkTemplate(CredentialsValidity.SELF_LINK_TEMPLATE));
        }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public bool IsValid { get; set; }
    }
}
