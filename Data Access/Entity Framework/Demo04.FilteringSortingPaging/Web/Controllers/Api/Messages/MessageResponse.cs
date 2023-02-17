namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            Valid = false;
            Message = string.Empty;
            Errors = new string[] { };
        }

        public bool Valid { get; set; }

        public string Message { get; set; }

        public string[] Errors { get; set; }
    }
}