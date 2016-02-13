
using SlidingApps.TaskRunner.Foundation.ReadModel;
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations
{
    public sealed class OrganizationCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/organizations?page={page}&pageSize={pageSize}";

        private OrganizationCollection()
        {
            this.templates.Add(new SelfLinkTemplate(OrganizationCollection.SELF_LINK_TEMPLATE));
            this.templates.Add(new PreviousLinkTemplate(OrganizationCollection.SELF_LINK_TEMPLATE));
        }

        public OrganizationCollection(IEnumerable<Organization> organizations)
            : this()
        {
            this.Organizations = organizations;
        }

        [HalJsonEmbedded("organizations")]
        public IEnumerable<Organization> Organizations { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.Organizations.ToList().ForEach(x => x.FormatLinks((new { OrganizationId = x.Id }).ActLike<IOrganizationFormatValues>()));
        }
    }
}
