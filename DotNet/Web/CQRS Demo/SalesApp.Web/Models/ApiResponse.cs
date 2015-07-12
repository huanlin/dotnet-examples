using System;

namespace SalesApp.Web.Models
{
    public class ApiResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }

        public ApiResponse()
        {
            Succeeded = false;
            Message = String.Empty;
            Errors = new string[] { };
        }

        public static ApiResponse OK(string message = "")
        {
            return new ApiResponse()
            {
                Succeeded = true,
                Message = message
            };
        }

        public static ApiResponse Error(string message, string[] errors = null)
        {
            var resp = new ApiResponse()
            {
                Succeeded = false,
                Message = message
            };
            if (errors != null && errors.Length > 0)
            {
                resp.Errors = errors;
            }
            return resp;
        }
    }
}