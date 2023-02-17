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

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, ISortOption sortOption)
        {
            if (!string.IsNullOrEmpty(sortOption.PropertyName))
            {
                return OrderByExpressionBuilder.OrderByProperty(query, sortOption.PropertyName, sortOption.IsDescending);
            }
            return query;
        }

        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> query, string propertyName, bool descending)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                return OrderByExpressionBuilder.OrderByProperty(query, propertyName, descending);
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

    // TODO: Move the following two expression builders to a better place in AFT.UGS.Core project (which folder?)
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


    public static class OrderByExpressionBuilder
    {
        private static readonly MethodInfo OrderByMethod =
            (from x in typeof(Queryable).GetMethods()
             where x.Name == "OrderBy"
             let pars = x.GetParameters()
             where pars.Length == 2
             select x).Single();

        private static readonly MethodInfo OrderByDescendingMethod =
            (from x in typeof(Queryable).GetMethods()
             where x.Name == "OrderByDescending"
             let pars = x.GetParameters()
             where pars.Length == 2
             select x).Single();

        public static IQueryable<TSource> OrderByProperty<TSource>(IQueryable<TSource> source, string propertyName, bool descending)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "t");
            Expression orderByProperty = Expression.Property(parameter, propertyName);

            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });

            MethodInfo genericMethod = null;

            if (@descending)
            {
                genericMethod = OrderByDescendingMethod.MakeGenericMethod(typeof(TSource), orderByProperty.Type);
            }
            else
            {
                genericMethod = OrderByMethod.MakeGenericMethod(typeof(TSource), orderByProperty.Type);
            }

            object result = genericMethod.Invoke(null, new object[] { source, lambda });

            return (IQueryable<TSource>)result;
        }
    }
}