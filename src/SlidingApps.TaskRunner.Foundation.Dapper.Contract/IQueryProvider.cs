
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public interface IQueryProvider
    {
        ICriteria<TEntity> From<TEntity>() where TEntity : class;

        IQueryProvider OrderBy<TEntity>(Expression<Func<TEntity, object>> property);

        IQueryProvider Limit(int page, int pageSize);

        TEntity SingleOrDefault<TEntity>() where TEntity : class;

        IList<TEntity> ToList<TEntity>() where TEntity : class;

        ICriterion<TEntity> CreateCriterion<TEntity>(string prefix) where TEntity : class;
    }
}
