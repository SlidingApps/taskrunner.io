
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations
{
    public sealed class TenantCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants?page={page}&pageSize={pageSize}";

        private TenantCollection()
        {
            this.templates.Add(new SelfLinkTemplate(TenantCollection.SELF_LINK_TEMPLATE));
            this.templates.Add(new PreviousLinkTemplate(TenantCollection.SELF_LINK_TEMPLATE));
        }

        public TenantCollection(IEnumerable<Tenant> tenants)
            : this()
        {
            this.Tenants = tenants;
        }

        [HalJsonEmbedded("tenants")]
        public IEnumerable<Tenant> Tenants { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.Tenants.ToList().ForEach(x => x.FormatLinks((new { TenantId = x.Id }).ActLike<ITenantFormatValues>()));
        }
    }
}
