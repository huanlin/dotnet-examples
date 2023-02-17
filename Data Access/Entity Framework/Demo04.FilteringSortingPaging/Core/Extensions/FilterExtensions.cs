using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AFT.UGS.Core.Interfaces.Extensions
{
    public static class FilterExtensions
    {
        // Where extension for filters of any nullable type
        public static IQueryable<TSource> Where<TSource, TFilter>(this IQueryable<TSource> source, TFilter? filter,
            Expression<Func<TSource, bool>> predicate) where TFilter : struct
        {
            if (filter.HasValue)
            {
                source = source.Where(predicate);
            }

            return source;
        }

        // Where extension for string filters
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, string filter,
            Expression<Func<TSource, bool>> predicate)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                source = source.Where(predicate);
            }

            return source;
        }

        // Where extension for collection filters
        public static IQueryable<TSource> Where<TSource, TFilter>(this IQueryable<TSource> source, IEnumerable<TFilter> filter,
            Expression<Func<TSource, bool>> predicate)
        {
            if (filter != null && filter.Any())
            {
                source = source.Where(predicate);
            }

            return source;
        }
    }
}