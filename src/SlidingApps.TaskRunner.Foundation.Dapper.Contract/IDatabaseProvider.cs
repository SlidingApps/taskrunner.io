
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;
using SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    /// <summary>
    /// Interface defining the API for the entity context.
    /// </summary>
    public interface IDatabaseProvider
        : IDisposable 
    {
        /// <summary>
        /// Gets the entity filtered by the given <see cref="ICriteria"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity matching the given criteria.</returns>
        TEntity Get<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        /// <remarks>The SQL clause WHERE is ignored while formatting the statement.</remarks>
        IList<TEntity> GetAll<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;

        /// <summary>
        /// Gets the entity set.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="clauses">The SQL clauses, ex. SELECT, FROM, WHERE, ...</param>
        /// <returns>The entity set of the given entity type.</returns>
        IList<TEntity> GetList<TEntity>(IEnumerable<IQueryLanguageClause> clauses) where TEntity : class;
    }
}
