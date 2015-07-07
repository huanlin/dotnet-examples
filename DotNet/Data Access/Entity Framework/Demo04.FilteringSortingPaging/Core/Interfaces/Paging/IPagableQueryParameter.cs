
using System.Collections.Generic;

namespace AFT.UGS.Core.Interfaces.Queries.Paging
{

    public interface ISortOption
    {
        string PropertyName { get; set; }
        bool IsDescending { get; set; }
    }


    public enum FilterOperator
    {
        Equal = 0,
        NotEqual,
        Contain,
        LessThan,
        LargerThan
    };

    public interface IFilterOption
    {
        string PropertyName { get; set; }
        FilterOperator Operator { get; set; }
        object Value { get; set; }
    }

    public interface IPagableQueryParameter
    {
        int Page { get; set; }

        int PageSize { get; set; }

        ISortOption SortOption { get; set; }

        List<IFilterOption> FilterOptions { get; set; }

        bool ShowAll { get; set; }
    }
}
