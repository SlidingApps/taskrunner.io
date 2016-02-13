
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using NHibernate;
using NHibernate.SqlCommand;
using System;

namespace SlidingApps.TaskRunner.Foundation.NHibernate
{
    /// <summary>
    /// The NHibernate <see cref="IInterceptor"/> that intercepts the executed SQL statement.
    /// </summary>
    public class NhibernateSqlInterceptor
        : EmptyInterceptor, IInterceptor
    {
        SqlString IInterceptor.OnPrepareStatement(SqlString sql)
        {
            NHibernateSql.LastSqlStatement = sql.ToString();
            Logger.Log.InfoFormat(Logger.LONG_CONTENT, "prepared sql", NHibernateSql.LastSqlStatement);

            return sql;
        }

        bool IInterceptor.OnSave(object entity, object id, object[] state, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            if (entity is IAuditableDataEntity)
            {
                var _entity = entity as IAuditableDataEntity;
                _entity._Modifier = "PLATFORM";
                this.SetStateValue(propertyNames, AuditableDataEntity.MODIFIER_ENTITY_AUDIT_FIELD, state, _entity._Modifier);

                _entity._Timestamp = DateTime.UtcNow;
                this.SetStateValue(propertyNames, AuditableDataEntity.TIMESTAMP_ENTITY_AUDIT_FIELD, state, _entity._Timestamp);
            }

            return true;
        }

        bool IInterceptor.OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            if (entity is IAuditableDataEntity)
            {
                var _entity = entity as IAuditableDataEntity;
                _entity._Modifier = "PLATFORM";
                this.SetStateValue(propertyNames, AuditableDataEntity.MODIFIER_ENTITY_AUDIT_FIELD, currentState, _entity._Modifier);

                _entity._Timestamp = DateTime.UtcNow;
                this.SetStateValue(propertyNames, AuditableDataEntity.TIMESTAMP_ENTITY_AUDIT_FIELD, currentState, _entity._Timestamp);
            }

            return true;
        }

        /// <summary>
        /// Sets the value of a property in the entity state. The entity state are the values of the individual properties in the entity 
        /// which are going to be committed to the database.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        /// <param name="state">The state to be inserted or updated to the database.</param>
        /// <param name="property">The name of the property to set.</param>
        /// <param name="value">The new value of the property.</param>
        private void SetStateValue(string[] propertyNames, string property, object[] state, object value)
        {
            int index = Array.FindIndex(propertyNames, name => property.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (index < 0) throw new InvalidOperationException(string.Format("Property not mapped: {0}", property));

            state[index] = value;
        }


    }
}
