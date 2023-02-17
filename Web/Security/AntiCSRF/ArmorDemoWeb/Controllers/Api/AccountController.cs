using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Security;
using ArmorDemoWeb.Models;
using Newtonsoft.Json;

namespace ArmorDemoWeb.Controllers.Api
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [HttpGet, Route("login")]
        public HttpResponseMessage Login(string userName, string password)
        {
            var userData = JsonConvert.SerializeObject(new
            {
                UserName = userName,
                Role = "Admin"
            });

            var ticket = new FormsAuthenticationTicket(
                1, 
                userName, 
                DateTime.UtcNow, 
                DateTime.UtcNow.AddMinutes(30),
                false,
                userData);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new CookieHeaderValue("auth-ticket", encryptedTicket);            

            var resp = Request.CreateResponse(HttpStatusCode.OK, encryptedTicket);
            resp.Headers.AddCookies(new [] { cookie });
            return resp;
        }

        public UserTicketModel GetUserTicket()
        {
            return new UserTicketModel();
        }
    }
}