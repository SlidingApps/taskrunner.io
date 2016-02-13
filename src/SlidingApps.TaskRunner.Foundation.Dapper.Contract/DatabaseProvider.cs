
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;
using SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    /// <summary>
    /// The base class of persistence context implementations.
    /// </summary>
    public abstract class DatabaseProvider
        : IDatabaseProvider
    {
        /// <summary>
        /// TRUE if the object is disposed, FALSE otherwise.
        /// </summary>
        private bool isDisposed = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected DatabaseProvider()
            : base() { }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~DatabaseProvider()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the entity filtered by the given <see cref="ICriteria"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity matching the given criteria.</returns>
        public abstract TEntity Get<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        /// <remarks>The SQL clause WHERE is ignored while formatting the statement.</remarks>
        public abstract IList<TEntity> GetAll<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        public abstract IList<TEntity> GetList<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.Dispose(true);
            }
            GC.SuppressFinalize(this);
        }

        #region - Private & protected methods -

        /// <summary>
        /// Disposes managed and unmanaged resources.
        /// </summary>
        /// <param name="isDisposing">Flag indicating how this protected method was called. 
        /// TRUE means via Dispose(), FALSE means via the destructor.
        /// Only in case of a call through the Dispose() method should managed resources be freed.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed) { }

            this.isDisposed = true;
        }

        #endregion
    }
}
