using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TraceWriterDemo.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get()
        {
            return DateTime.Now.ToString();
        }
    }
}
