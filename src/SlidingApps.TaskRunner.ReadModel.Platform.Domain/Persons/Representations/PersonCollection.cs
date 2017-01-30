﻿
using HalJsonNet.Configuration.Attributes;
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations
{
    public sealed class PersonCollection
        : CollectionRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants/{tenantId}/accounts?name={name}&page={page}&pageSize={pageSize}";

        private PersonCollection(int? page = null, int? pageSize = null)
            : base(page, pageSize)
        {
            this.templates.Add(new SelfLinkTemplate(PersonCollection.SELF_LINK_TEMPLATE));
            this.templates.Add(new PreviousLinkTemplate(PersonCollection.SELF_LINK_TEMPLATE));
        }

        public PersonCollection(IEnumerable<Person> persons, int? page = null, int? pageSize = null)
            : this(page, pageSize)
        {
            this.Accounts = persons;
        }

        [HalJsonEmbedded("accounts")]
        public IEnumerable<Person> Accounts { get; set; }

        public override void FormatEmbeddedObjectLinks(IFormatValues values)
        {
            this.Accounts.ToList().ForEach(x => x.FormatLinks((new { x.TenantId, AccountId = x.Id }).ActLike<IPersonFormatValues>()));
        }
    }
}
