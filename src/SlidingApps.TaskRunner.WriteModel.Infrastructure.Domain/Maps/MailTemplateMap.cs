
using FluentNHibernate.Mapping;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain.Maps
{
    public class MailTemplateMap
        : AuditableDataEntityMap<Entities.MailTemplate, Guid>
    {
        /// <summary>
        /// The <see cref="Entities.MailTemplate"/> database table name.
        /// </summary>
        public const string TABLE_NAME = "Mail_Template_H";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MailTemplateMap()
            : base(Metadata.SCHEMA_NAME, MailTemplateMap.TABLE_NAME)
        {
            this.Map(x => x.Code);

            this.HasOne(x => x.Info).Cascade.All().PropertyRef(x => x.MailTemplate).LazyLoad(Laziness.Proxy);
        }
    }
}
