
using System.Collections.Generic;

namespace AFT.UGS.Core.Interfaces.Queries.Paging
{
    public interface IPagedList<T>
    {
        int TotalCount { get; }

        int PageCount { get; }

        int Page { get; }

        int PageSize { get; }

        List<T> Items { get; }
    }
}
