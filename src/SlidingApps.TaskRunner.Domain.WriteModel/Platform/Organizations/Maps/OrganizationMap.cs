
using SlidingApps.TaskRunner.Foundation.NHibernate;
using FluentNHibernate.Mapping;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Maps
{
    public class OrganizationMap
        : AuditableDataEntityMap<Entities.Organization, Guid>
    {
        /// <summary>
        /// The <see cref="Organization"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Organization_H";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrganizationMap()
            : base(Metadata.SCHEMA_NAME, OrganizationMap.TABLE_NAME)
        {
            this.Map(x => x.Code);

            this.HasOne(x => x.Info) .Cascade.All().PropertyRef(x => x.Organization).LazyLoad(Laziness.Proxy);
        }
    }
}
