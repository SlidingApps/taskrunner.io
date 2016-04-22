﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SlidingApps.TaskRunner.Foundation.Dapper.Filter
{
    public partial class Criteria
        : ICriteria
    {
        protected readonly IQueryProvider provider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Criteria(IQueryProvider provider)
        {
            this.provider = provider;

            this.Restrictions = new List<ICriterion>();
            this.AndCriteria = new List<ICriteria>();
            this.OrCriteria = new List<ICriteria>();
        }

        /// <summary>
        /// The restrictions.
        /// </summary>
        public IList<ICriterion> Restrictions { get; private set; }

        /// <summary>
        /// List of <see cref="Criteria"/> added as AND restrictions.
        /// </summary>
        public IList<ICriteria> AndCriteria { get; private set; }

        /// <summary>
        /// List of <see cref="Criteria"/> added as OR restrictions.
        /// </summary>
        public IList<ICriteria> OrCriteria { get; private set; }

        /// <summary>
        /// Clears the criteria.
        /// </summary>
        /// <returns></returns>
        public ICriteria Clear()
        {
            this.Restrictions.Clear();
            this.AndCriteria.Clear();
            this.OrCriteria.Clear();

            return this;
        }

        /// <summary>
        /// Add a list of <see cref="Criteria"/> to be combined with AND operator.
        /// </summary>
        /// <param name="andCriteria">The list of <see cref="Criteria"/>.</param>
        /// <returns>The <see cref="Criteria"/> instance.</returns>
        public ICriteria And(params ICriteria[] andCriteria)
        {
            this.AndCriteria = this.AndCriteria.Concat(andCriteria).ToList();

            return this;
        }

        /// <summary>
        /// Add a list of <see cref="Criteria"/> to be combined with OR operator.
        /// </summary>
        /// <param name="orCriteria">The list of <see cref="Criteria"/>.</param>
        /// <returns>The <see cref="Criteria"/> instance.</returns>
        public ICriteria Or(params ICriteria[] orCriteria)
        {
            this.OrCriteria = this.OrCriteria.Concat(orCriteria).ToList();

            return this;
        }

        public override string ToString()
        {
            string criteria = string.Join(" AND ", this.Restrictions.Select(x => x.ToString()).ToArray());

            string and = string.Join(") AND (", this.AndCriteria.Select(x => x.ToString()).ToArray());
            and = string.IsNullOrEmpty(and) ? String.Empty : string.Format("({0})", and);

            string or = string.Join(") OR (", this.OrCriteria.Select(x => x.ToString()).ToArray());
            or = string.IsNullOrEmpty(or) ? string.Empty : string.Format("({0})", or);

            string and_or = string.Empty;
            if (!string.IsNullOrEmpty(and) && string.IsNullOrEmpty(or))
            {
                and_or += and;
            }
            else if (string.IsNullOrEmpty(and) && !string.IsNullOrEmpty(or))
            {
                and_or += or;
            }
            else if (!string.IsNullOrEmpty(and) && !string.IsNullOrEmpty(or))
            {
                and_or += "(" + and + ") AND (" + or + ")";
            }

            if (!string.IsNullOrEmpty(criteria) && string.IsNullOrEmpty(and_or))
            {
                criteria += and_or;
            }
            else if (string.IsNullOrEmpty(criteria) && !string.IsNullOrEmpty(and_or))
            {
                criteria += and_or;
            }
            else if (!string.IsNullOrEmpty(criteria) && !string.IsNullOrEmpty(and_or))
            {
                criteria = criteria + " AND (" + and_or + ") ";
            }

            return criteria;
        }
    }

    public partial class Criteria<TEntity> 
        : Criteria, ICriteria<TEntity>
        where TEntity: class
    {
        private readonly IMappingProvider mappingProvider;


        public Criteria(IQueryProvider provider, IMappingProvider mappingProvider)
            : base(provider)
        {
            this.mappingProvider = mappingProvider;
        }

        /// <summary>
        /// Add a <see cref="Criterion"/> as a restriction.
        /// </summary>
        /// <typeparam name="TEntity">The entity type of the <see cref="Criterion"/></typeparam>
        /// <param name="property">The entity property expression.</param>
        /// <returns>The <see cref="Criteria"/> the <see cref="Criterion"/> was added to.</returns>
        public ICriterion<TEntity> By(Expression<Func<TEntity, object>> property)
        {
            ICriterion<TEntity> criterion = null;

            PropertyInfo propertyInfo = null;
            if (property.Body is MemberExpression)
            {
                propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                MemberExpression memberExpression = ((UnaryExpression)property.Body).Operand as MemberExpression;
                if (memberExpression != null) propertyInfo = memberExpression.Member as PropertyInfo;
            }

            if (propertyInfo != null)
            {
                string prefix = this.mappingProvider.GetMapping<TEntity>().GetSchemaAndTableName();
                criterion = this.provider.CreateCriterion<TEntity>(prefix);
                criterion.Criteria = this;
                criterion.Field = propertyInfo.Name;

                this.Restrictions.Add(criterion);
            }

            return criterion;
        }

        public IQueryProvider OrderBy(Expression<Func<TEntity, object>> property)
        {
            return this.provider.OrderBy(property);
        }

        public IQueryProvider Limit(int page, int pageSize)
        {
            return this.provider.Limit(page, pageSize);
        }

        public TEntity SingleOrDefault()
        {
            return this.provider.SingleOrDefault<TEntity>();
        }

        public IList<TEntity> ToList()
        {
            return this.provider.ToList<TEntity>();
        }
    }
}
