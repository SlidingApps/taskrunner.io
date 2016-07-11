
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Tenants.Maps
{
    public class DomainMap
        : AuditableDataEntityMap<Entities.Domain, Guid>
    {
        /// <summary>
        /// The <see cref="Tenant"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Domain_H";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DomainMap()
            : base(Metadata.SCHEMA_NAME, DomainMap.TABLE_NAME)
        {
            this.Map(x => x.Code);

            this.HasOne(x => x.Info) .Cascade.All().PropertyRef(x => x.Domain).LazyLoad(Laziness.Proxy);
        }
    }
}
