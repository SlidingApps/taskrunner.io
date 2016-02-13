
using SlidingApps.TaskRunner.Foundation.WriteModel;
using FluentNHibernate.Mapping;

namespace SlidingApps.TaskRunner.Foundation.NHibernate
{
    /// <summary>
    /// The NHibernate mapping for an <see cref="AuditableDataEntity{TIdentifier}"/>.
    /// </summary>
    /// <typeparam name="TAuditableDataEntity">The type of <see cref="AuditableDataEntity{TIdentifier}"/>.</typeparam>
    /// <typeparam name="TIdentifier">The identifier of the <see cref="AuditableDataEntity{TIdentifier}"/>.</typeparam>
    public abstract class AuditableDataEntityMap<TAuditableDataEntity, TIdentifier>
        : ClassMap<TAuditableDataEntity>
        where TAuditableDataEntity : AuditableDataEntity<TIdentifier>
    {
        private const string MODIFIER_AUDIT_FIELD = "_Modifier";
        private const string TIMESTAMP_AUDIT_FIELD = "_Timestamp";
        private const string VERSION_AUDIT_FIELD = "_Version";

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="table">The database table name.</param>
        public AuditableDataEntityMap(string table)
            : this(string.Empty, table)
        { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="schema">The database schema name.</param>
        /// <param name="table">The database table name.</param>
        public AuditableDataEntityMap(string schema, string table)
        {
            this.Schema(schema);
            this.Table(table);

            this.DynamicInsert();
            this.DynamicUpdate();

            this.Id(x => x.Id).GeneratedBy.Assigned();

            this.Map(x => x._Modifier).Column(MODIFIER_AUDIT_FIELD);
            this.Map(x => x._Timestamp).Column(TIMESTAMP_AUDIT_FIELD);

            this.Version(x => x._Version).Column(VERSION_AUDIT_FIELD); ;
        }
    }
}
