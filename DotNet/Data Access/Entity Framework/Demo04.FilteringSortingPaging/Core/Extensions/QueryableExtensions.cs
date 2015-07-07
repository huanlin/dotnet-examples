using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AFT.UGS.Core.Interfaces.Queries.Paging;

namespace AFT.UGS.Core.Interfaces.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T, TProperty>(this IQueryable<T> query,
            Expression<Func<T, TProperty>> getColumnFunc, bool isDescending)
        {
            if (isDescending)
            {
                return query.OrderByDescending(getColumnFunc);
            }
            return query.OrderBy(getColumnFunc);
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, ISortOption sortOption)
        {
            if (!string.IsNullOrEmpty(sortOption.PropertyName))
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(sortOption.PropertyName);

                if (propertyInfo != null)
                {
                    if (sortOption.IsDescending)
                    {
                        return query.OrderByDescending(x => propertyInfo.GetValue(x, null));
                    }
                    else
                    {
                        return query.OrderBy(x => propertyInfo.GetValue(x, null));
                    }
                }
            }
            return query;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, List<IFilterOption> filterOptions)
        {
            var expr = WhereExpressionBuilder.GetExpression<T>(filterOptions);
            if (expr != null)
            {
                return query.Where(expr);
            }
            return query;
        }
    }

    public static class WhereExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");

        public static Expression<Func<T, bool>> GetExpression<T>(List<IFilterOption> filters)
        {
            if (filters.Count == 0)
            {
                return null;
            }

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, IFilterOption filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);

            switch (filter.Operator)
            {
                case FilterOperator.Equal:
                    return Expression.Equal(member, constant);

                case FilterOperator.Contain:
                    return Expression.Call(member, containsMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>(ParameterExpression param, IFilterOption filter1, IFilterOption filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
}