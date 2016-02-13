
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations
{
    public sealed class Person
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/organizations/{organizationId}/persons/{personId}";

        private Person()
        {
            this.templates.Add(new SelfLinkTemplate(Person.SELF_LINK_TEMPLATE));
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public string DisplayName { get; set; }

        public string Info { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid OrganizationId { get; set; }

        public string OrganizationCode { get; set; }
    }
}
