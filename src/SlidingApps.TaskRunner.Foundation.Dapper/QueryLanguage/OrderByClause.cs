
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SlidingApps.TaskRunner.Foundation.Dapper.QueryLanguage
{
    public class OrderByClause<TEntity>
        : IQueryLanguageClause
    {
        private const int CLAUSE_ORDER = 400;

        private const string CLAUSE_TEMPLATE = "ORDER BY {0}.{1} ASC";

        public OrderByClause(string prefix, Expression<Func<TEntity, object>> property)
        {
            this.Prefix = prefix;
            this.Property = property;
        }

        public string Prefix { get; private set; }

        public Expression<Func<TEntity, object>> Property { get; private set; }

        public int Order
        {
            get { return CLAUSE_ORDER; }
        }

        public override string ToString()
        {
            string orderBy = string.Empty;

            PropertyInfo propertyInfo = null;
            if (this.Property.Body is MemberExpression)
            {
                propertyInfo = (this.Property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                MemberExpression memberExpression = ((UnaryExpression)this.Property.Body).Operand as MemberExpression;
                if (memberExpression != null) propertyInfo = memberExpression.Member as PropertyInfo;
            }

            if (propertyInfo != null)
            {
                orderBy = string.Format(CLAUSE_TEMPLATE, this.Prefix, propertyInfo.Name);
            }

            return orderBy;
        }
    }
}
