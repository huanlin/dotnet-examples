
namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages.Player
{
    public class GetPlayersRequest : PageableRequest
    {
        // filters
        public string Username { get; set; }
        public string BrandName { get; set; }
        public string LicenseeName { get; set; }
        public string Currency { get; set; }
    }
}