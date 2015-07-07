using System.Collections.Generic;
using AFT.UGS.Core.Interfaces.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries.Paging
{
    public class PagableQueryParameter : IPagableQueryParameter
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public ISortOption SortOption { get; set; }

        public List<IFilterOption> FilterOptions { get; set; }

        public bool ShowAll { get; set; }

        public PagableQueryParameter()
        {
            SortOption = null;
            FilterOptions = new List<IFilterOption>();
        }
    }
}
