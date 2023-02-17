using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages;
using PagedList;

namespace AFT.UGS.Web.UgsBackendWebsite.Extensions
{
    public static class PagingExtentions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> repository, PageableRequest request) where T : class
        {
            if (request.ShowAll)
            {
                return repository;
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(request.SortBy);

                if (propertyInfo != null)
                {
                    repository = string.Compare(request.OrderBy.ToLower(), "desc", StringComparison.Ordinal) == 0
                        ? (from x in repository orderby propertyInfo.GetValue(x, null) descending select x)
                        : (from x in repository orderby propertyInfo.GetValue(x, null) select x);
                }
            }

            return repository.ToPagedList(request.Page, request.Rows);
        }

        public static TConverted[] ToPagedArray<T, TConverted>(this IEnumerable<T> repository, PageableRequest request, Func<T, TConverted> converter)
            where T : class
            where TConverted : class
        {
            return ToPagedList(repository, request).Select(converter).ToArray();
        }
    }
}