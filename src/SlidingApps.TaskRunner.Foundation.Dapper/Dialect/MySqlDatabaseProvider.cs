
using SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.Dapper.Dialect
{
    /// <summary>
    /// The base class for NHibernate entity context implementations.
    /// </summary>
    [DatabaseType("MySql.Data.MySqlClient")]
    public sealed class MySqlDatabaseProvider
        : DatabaseProvider
    {
        private readonly IMappingProvider mappingProvider;

        /// <summary>
        /// TRUE if the object is disposed, FALSE otherwise.
        /// </summary>
        private bool isDisposed = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MySqlDatabaseProvider(IMappingProvider mappingProvider) :
            base()
        {
            this.mappingProvider = mappingProvider;
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~MySqlDatabaseProvider()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the entity filtered by the given <see cref="ICriteria"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity matching the given criteria.</returns>
        public override TEntity Get<TEntity>(IEnumerable<IQueryLanguageClause> clauses)
        {
            return this.GetList<TEntity>(clauses).SingleOrDefault();
        }

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        /// <remarks>The SQL clause WHERE is ignored while formatting the statement.</remarks>
        public override IList<TEntity> GetAll<TEntity>(IEnumerable<IQueryLanguageClause> clauses)
        {
            Argument.InstanceIsRequired(clauses, "clauses");

            string query = string.Join(" ", clauses.Where(x=> !(x is WhereClause)).OrderBy(x => x.Order));
            Logger.Log.InfoFormat(Logger.LONG_CONTENT, "executing query", query);

            var mapping = this.mappingProvider.GetMapping<TEntity>();
            IDbConnection connection = DatabaseHelper.CreateDbConnection(mapping.Schema.ProviderName, mapping.Schema.Connectionstring);
            IEnumerable<TEntity> entities = connection.Query<TEntity>(query);

            Logger.Log.DebugFormat(Logger.LONG_CONTENT, "query executed", query);

            return entities.ToList();
        }

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        public override IList<TEntity> GetList<TEntity>(IEnumerable<IQueryLanguageClause> clauses)
        {
            Argument.InstanceIsRequired(clauses, "clauses");

            string query = string.Join(" ", clauses.OrderBy(x => x.Order));
            Logger.Log.InfoFormat(Logger.LONG_CONTENT, "executing query", query);

            var mapping = this.mappingProvider.GetMapping<TEntity>();
            IDbConnection connection = DatabaseHelper.CreateDbConnection(mapping.Schema.ProviderName, mapping.Schema.Connectionstring);
            IEnumerable<TEntity> entities = connection.Query<TEntity>(query);

            Logger.Log.DebugFormat(Logger.LONG_CONTENT, "query executed", query);

            return entities.ToList();
        }

        /// <summary>
        /// Disposes the managed and unmanaged resources.
        /// </summary>
        /// <param name="isDisposing">TRUE if disposing and managed resources should be disposed, FALSE otherwise.</param>
        protected override void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing) { }
            }

            base.Dispose(isDisposing);
        }
    }
}
