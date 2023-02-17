using System;
using AFT.UGS.Core.Interfaces.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries.Paging
{
    public class SortOption : ISortOption
    {
        public string PropertyName { get; set; }
        public bool IsDescending { get; set; }

        public SortOption(string propertyName, bool isDescending)
        {
            IsDescending = isDescending;
            PropertyName = propertyName;
        }

        public SortOption(string sortClause)
        {
            string[] columnNameAndOrder = sortClause.Split(' ');
            if (columnNameAndOrder.Length < 2)
            {
                throw new ArgumentException("Invalid parameter", "sortClause");
            }
            PropertyName = columnNameAndOrder[0];
            IsDescending = "desc".Equals(columnNameAndOrder[1], StringComparison.OrdinalIgnoreCase);
        }

        public static SortOption Empty()
        {
            return new SortOption(String.Empty, false);
        }
    }
}
