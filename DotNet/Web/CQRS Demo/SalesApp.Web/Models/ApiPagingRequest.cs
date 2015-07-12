
using System;

namespace SalesApp.Web.Models
{
    public abstract class ApiPagingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }   // Example: "Name desc"

        public ApiPagingRequest()
        {
            Page = 0;
            PageSize = 0;
            SortOrder = String.Empty;
        }
    }
}