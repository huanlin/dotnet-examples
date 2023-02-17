using System;
using System.Web.Http.Tracing;
using NLog;

namespace TraceWriterDemo.Infrastructure
{
    /// <summary>
    /// This class shows how to log every HTTP request to your Web API.
    /// </summary>
    public class WebApiTraceWriter : ITraceWriter
    {
        private Logger _logger;
        private Guid _lastRequestId; // This is just a workaround for duplicated entries. Remove this after the duplication issue is solved.

        public WebApiTraceWriter()
        {
            _logger = NLog.LogManager.GetLogger("WebApiTraceWriter");   // The logger name must be defined in Nlog.config file.
        }

        public void Trace(System.Net.Http.HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                TraceRecord traceRecord = new TraceRecord(request, category, level);
                traceAction(traceRecord);
                Log(traceRecord);
            }
        }

        private void Log(TraceRecord traceRecord) 
        {
            if (traceRecord.Request == null || traceRecord.Request.Method == null || traceRecord.Request.RequestUri == null)
            {
                return;
            }
            if (traceRecord.RequestId.Equals(_lastRequestId)) // Skip the request that has already logged.
            {
                return;
            }
            _lastRequestId = traceRecord.RequestId;
            string s = String.Format("{0} {1}\r\n", traceRecord.Request.Method, traceRecord.Request.RequestUri);
            _logger.Debug(s);

            //System.IO.File.AppendAllText(@"C:\temp\log.txt", s);
        }
    }
}