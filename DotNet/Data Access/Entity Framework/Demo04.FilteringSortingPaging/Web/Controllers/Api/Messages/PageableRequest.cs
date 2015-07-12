namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages
{
    public class PageableRequest
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string OrderBy { get; set; }

        public string SortBy { get; set; }

        public bool ShowAll { get; set; }
    }
}