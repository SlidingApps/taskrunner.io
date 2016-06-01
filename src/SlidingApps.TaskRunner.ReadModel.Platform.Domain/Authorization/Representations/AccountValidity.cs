
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations
{
    public class AccountValidity
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        public AccountValidity()
        {
            this.templates.Add(new SelfLinkTemplate(AccountValidity.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public bool IsValid { get; set; }
    }
}
