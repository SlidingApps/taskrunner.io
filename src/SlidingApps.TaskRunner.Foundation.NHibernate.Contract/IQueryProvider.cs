
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using NHibernate;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.NHibernate
{
    public interface IQueryProvider<TSession>
        where TSession : ISession
    {
        TSession Session { get; }

        IQueryable<TEntity> CreateQuery<TEntity>();

        TEntity SingleOrDefault<TWithFilterExpression, TEntity>(TWithFilterExpression query)
            where TWithFilterExpression : IWithFilterExpression<TEntity>, Cqrs.IQuery
            where TEntity : class, IDataEntity;

        IQueryable<TEntity> Find<TWithFilterExpression, TEntity>(TWithFilterExpression query)
            where TWithFilterExpression : IWithFilterExpression<TEntity>, Cqrs.IQuery
            where TEntity : class, IDataEntity;
    }
}
