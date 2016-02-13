
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SlidingApps.TaskRunner.Foundation.Dapper.Filter
{
    public interface ICriteria
    {
        IList<ICriterion> Restrictions { get; }

        IList<ICriteria> AndCriteria { get; }

        IList<ICriteria> OrCriteria { get; }

        ICriteria Clear();

        ICriteria And(params ICriteria[] andCriteria);

        ICriteria Or(params ICriteria[] orCriteria);
    }

    public interface ICriteria<TEntity>
        : ICriteria
        where TEntity : class
    {
        ICriterion<TEntity> By(Expression<Func<TEntity, object>> property);

        IQueryProvider OrderBy(Expression<Func<TEntity, object>> property);

        IQueryProvider Limit(int page, int pageSize);

        TEntity SingleOrDefault();

        IList<TEntity> ToList();
    }
}