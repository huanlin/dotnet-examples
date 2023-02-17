using System.Collections.Generic;
using System.Linq;
using AFT.UGS.Core.Interfaces.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public int TotalCount { get; private set; }

        public int PageCount { get; private set; }

        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public List<T> Items { get; private set; }

        public PagedList(IQueryable<T> source, int page, int pageSize)
        {
            TotalCount = source.Count();
            PageCount = GetPageCount(pageSize, TotalCount);
            Page = page < 0 ? 0 : page - 1;
            PageSize = pageSize;

            Items = new List<T>(source.Skip(Page * PageSize).Take(PageSize).ToList());
        }

        private int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }

        public static IPagedList<T> Create(IQueryable<T> source, int page, int pageSize)
        {
            return new PagedList<T>(source, page, pageSize);
        }

        public static T[] ToPagedArray(IQueryable<T> source, int page, int pageSize, out int totalCount)
        {
            totalCount = source.Count();
            page = page < 0 ? 0 : page - 1;

            return source.Skip(page * pageSize).Take(pageSize).ToArray();
        }
    }

    public static class PagedListExtensions
    {
        public static T[] ToPagedArray<T>(this IQueryable<T> query, int page, int pageSize, out int totalCount)
        {
            return PagedList<T>.ToPagedArray(query, page, pageSize, out totalCount);
        }
    }
}