
using SlidingApps.TaskRunner.Foundation.ReadModel;
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations
{
    public sealed class PersonCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/organizations/{organizationId}/persons?name={name}&page={page}&pageSize={pageSize}";

        private PersonCollection(int? page = null, int? pageSize = null)
            : base(page, pageSize)
        {
            this.templates.Add(new SelfLinkTemplate(PersonCollection.SELF_LINK_TEMPLATE));
            this.templates.Add(new PreviousLinkTemplate(PersonCollection.SELF_LINK_TEMPLATE));
        }

        public PersonCollection(IEnumerable<Person> persons, int? page = null, int? pageSize = null)
            : this(page, pageSize)
        {
            this.Persons = persons;
        }

        [HalJsonEmbedded("persons")]
        public IEnumerable<Person> Persons { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.Persons.ToList().ForEach(x => x.FormatLinks((new { x.OrganizationId, PersonId = x.Id }).ActLike<IPersonFormatValues>()));
        }
    }
}
