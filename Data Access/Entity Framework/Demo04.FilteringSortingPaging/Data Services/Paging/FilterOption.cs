using AFT.UGS.Core.Interfaces.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries.Paging
{
    public class FilterOption : IFilterOption
    {
        public string PropertyName { get; set; }
        public FilterOperator Operator { get; set; }
        public object Value { get; set; }
    }
}
