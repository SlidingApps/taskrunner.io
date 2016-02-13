
using Autofac;
using SlidingApps.TaskRunner.Foundation.Dapper.Filter;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage;
using SlidingApps.TaskRunner.Foundation.Dapper.Dialect;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public delegate ICriteria CriteriaFactory(Type serviceType);

    public delegate ICriterion CriterionFactory(Type serviceType);

    public class QueryProvider
		: IQueryProvider
    {
        private readonly IComponentContext context;

        private readonly IMappingProvider mappingProvider;

        private readonly IDatabaseProviderFactory databaseProviderFactory;

        private readonly List<IQueryLanguageClause> clauses = new List<IQueryLanguageClause>();

        private ICriteria criteria;

        public QueryProvider(IComponentContext context, IMappingProvider mappingProvider, IDatabaseProviderFactory databaseProviderFactory)
        {
            this.context = context;
            this.mappingProvider = mappingProvider;
            this.databaseProviderFactory = databaseProviderFactory;
        }

        public ICriteria<TEntity> From<TEntity>() where TEntity : class
        {
            this.criteria = this.context.Resolve<CriteriaFactory>().Invoke(typeof(TEntity)) as ICriteria;

            return this.criteria as ICriteria<TEntity>;
        }

		public ICriterion<TEntity> CreateCriterion<TEntity>(string prefix) where TEntity : class
        {
			var criterion = this.context.Resolve<ICriterion<TEntity>>();
			criterion.Prefix = prefix;

			return criterion;
        }

        public IQueryProvider OrderBy<TEntity>(Expression<Func<TEntity, object>> property)
        {
            this.clauses.Add(new OrderByClause<TEntity>(this.mappingProvider.GetMapping<TEntity>().Table, property));

            return this;
        }

        public IQueryProvider Limit(int page, int pageSize)
        {
            this.clauses.Add(new LimitClause(page, pageSize));

            return this;
        }

        public TEntity SingleOrDefault<TEntity>() where TEntity : class
        {
            var name = this.mappingProvider.GetMapping<TEntity>().Schema.ProviderName;
            var provider = this.databaseProviderFactory.Resolve(name);

            this.clauses.Add(new SelectClause("*"));
            this.clauses.Add(new FromClause(this.mappingProvider.GetMapping<TEntity>().Table));
            this.clauses.Add(new WhereClause(this.criteria));

            return provider.Get<TEntity>(this.clauses);
        }

        public IList<TEntity> ToList<TEntity>() where TEntity : class
        {
            var name = this.mappingProvider.GetMapping<TEntity>().Schema.ProviderName;
            var provider = this.databaseProviderFactory.Resolve(name);

            this.clauses.Add(new SelectClause("*"));
            this.clauses.Add(new FromClause(this.mappingProvider.GetMapping<TEntity>().Table));
            this.clauses.Add(new WhereClause(this.criteria));

            return provider.GetList<TEntity>(this.clauses);
        }
    }
}
