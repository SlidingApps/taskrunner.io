
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Authorization.Representations
{
    public class PersonCredentialsCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/auth";

        private PersonCredentialsCollection(int? page = null, int? pageSize = null)
            : base(page, pageSize)
        {
            this.templates.Add(new SelfLinkTemplate(PersonCredentialsCollection.SELF_LINK_TEMPLATE));
        }

        public PersonCredentialsCollection(IEnumerable<PersonCredentials> accountCredentials, int? page = null, int? pageSize = null)
            : this(page, pageSize)
        {
            this.AccountCredentials = accountCredentials;
        }

        [HalJsonEmbedded("accountcredentials")]
        public IEnumerable<PersonCredentials> AccountCredentials { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.AccountCredentials.ToList().ForEach(x => x.FormatLinks((new { }).ActLike<IPersonCredentialsFormatValues>()));
        }
    }
}
