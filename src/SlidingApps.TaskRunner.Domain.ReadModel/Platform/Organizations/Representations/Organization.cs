
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations
{
    public sealed class Organization
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/organizations/{organizationId}";

        private Organization()
        {
            this.templates.Add(new SelfLinkTemplate(Organization.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
