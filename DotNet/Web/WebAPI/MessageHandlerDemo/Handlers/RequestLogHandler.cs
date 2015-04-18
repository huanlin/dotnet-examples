using System;
using System.Web;
using System.Net.Http;

namespace MessageHandlerDemo.Handlers
{
    public class RequestLogHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            LogRequest(request);

            return base.SendAsync(request, cancellationToken);
        }

        private void LogRequest(HttpRequestMessage request)
        {
            var info = new RequestLogInfo
            {
                HttpMethod = request.Method.Method,
                UriAccessed = request.RequestUri.AbsoluteUri,
                IPAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0",
            };

            if (request.Content != null)
            {
                request.Content.ReadAsByteArrayAsync()
                    .ContinueWith((task) =>
                    {
                        info.BodyContent = System.Text.UTF8Encoding.UTF8.GetString(task.Result);
                    });
            }

            // Serialize to JSON string.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
            string uniqueid = DateTime.Now.Ticks.ToString();
            string logfile = String.Format("C:\\Temp\\{0}.txt", uniqueid);
            System.IO.File.WriteAllText(logfile, json);
        }
    }

    public class RequestLogInfo
    {
        //public List<string> Header { get; set; }
        public string HttpMethod { get; set; }
        public string UriAccessed { get; set; }
        public string IPAddress { get; set; }
        public string BodyContent { get; set; }
    }
}