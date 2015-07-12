
using System;

namespace SalesApp.Web.Controllers.Api.Messages
{
    public class ResponseMessageBase
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }

        public ResponseMessageBase()
        {
            Valid = false;
            Message = String.Empty;
            Errors = new string[] {};
        }
    }
}