using System;
using System.Collections.Generic;

namespace AFT.UGS.Core.Interfaces.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            var en = enumerable.GetEnumerator();
            while (en.MoveNext())
            {
                action(en.Current);
            }
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
        {
            return new HashSet<T>(enumerable);
        }
        public static HashSet<TOut> ToHashSet<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> get)
        {
            var set = new HashSet<TOut>();
            var en = enumerable.GetEnumerator();
            while (en.MoveNext())
            {
                set.Add(get(en.Current));
            }
            return set;
        }

        public static IList<T[]> ToArraySegmentsOfMax<T>(this IEnumerable<T> enumerable, int limit)
        {
            if(limit < 1) throw new ArgumentException("limit for ToArraySegmentsOfMax cannot be less than 1");
            var arrays = new List<T[]>();
            var current = new List<T>(limit);
            foreach (var e in enumerable)
            {
                current.Add(e);
                if (current.Count == limit)
                {
                    arrays.Add(current.ToArray());
                    current = new List<T>(limit);
                }
            }
            if (current.Count > 0)
            {
                arrays.Add(current.ToArray());
            }
            return arrays;
        } 
    }
}