
using System;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
    public class AuditableDataEntity
    {
        public const string MODIFIER_ENTITY_AUDIT_FIELD = "_Modifier";
        public const string TIMESTAMP_ENTITY_AUDIT_FIELD = "_Timestamp";
        public const string VERSION_ENTITY_AUDIT_FIELD = "_Version";
    }

    /// <summary>
    /// An <see cref="DataEntity{TIdentifier}"/> with audit fields.
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier, ex. <see cref="Guid"/>.</typeparam>
    public abstract class AuditableDataEntity<TIdentifier>
        : DataEntity<TIdentifier>, IAuditableDataEntity
    {
        protected AuditableDataEntity()
            : base() { }

        protected AuditableDataEntity(TIdentifier id)
            : base()
        {
            this.Id = id;
        }

        public virtual string _Modifier { get; set; }

        public virtual DateTime _Timestamp { get; set; }

        public virtual int _Version { get; set; }
    }
}
