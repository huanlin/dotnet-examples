using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AFT.UGS.Core.Interfaces.Queries;
using AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages.ApiCallLog;
using AFT.UGS.Web.UgsBackendWebsite.Extensions;
using AFT.UGS.Web.UgsBackendWebsite.Filters.Api;

namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api
{
    [AdminOnly]
    [RoutePrefix("api/apiCallLogs")]
    public class ApiCallLogController : ApiController
    {
        private readonly IApiCallLogQueries _apiCallLogQueries;

        public ApiCallLogController(IApiCallLogQueries apiCallLogQueries)
        {
            _apiCallLogQueries = apiCallLogQueries;
        }

        [HttpGet, Route("admin")]
        public async Task<GetApiCallLogsForAdminResponse> GetApiCallLogsForAdminAsync([FromUri] GetApiCallLogsRequest request)
        {
            int diffTimeZoneOffset = DateTimeOffset.Now.Offset.Hours - request.TimeZoneOffset;
            DateTime from = request.From.AddHours(diffTimeZoneOffset);
            DateTime to = request.To.AddDays(1).AddHours(diffTimeZoneOffset);

            var apiCallLogs =
                await
                    _apiCallLogQueries.GetApiCallLogsAsync(request.Ip, request.Path, request.RequestHeaders,
                        request.RequestContent, request.ResponseHeaders, request.ResponseContent, from, to);

            var apiCallLogModels = apiCallLogs.Select(apiCallLog => new ApiCallLogForAdminModel
            {
                Ip = apiCallLog.Ip,
                ExecutionTimeMs = apiCallLog.ExecutionTimeMs,
                Id = apiCallLog.Id,
                ThreadId = apiCallLog.ThreadId,
                Method = apiCallLog.Method,
                Path = apiCallLog.Path,
                Prefix = apiCallLog.Prefix,
                RecordedOn = apiCallLog.RecordedOn,
                ServerName = apiCallLog.ServerName,
                ResponseContent = apiCallLog.ResponseContent,
                ResponseHeaders = apiCallLog.ResponseHeaders,
                ResponseCode = apiCallLog.ResponseCode,
                ResponsePhrase = apiCallLog.ResponsePhrase,
                RequestHeaders = apiCallLog.RequestHeaders,
                RequestContent = apiCallLog.RequestContent
            });

            return new GetApiCallLogsForAdminResponse
            {
                Valid = true,
                TotalCount = apiCallLogs.Count(),
                ApiCallLogs = apiCallLogModels.ToPagedList(request).ToArray()
            };
        }

        [HttpGet, Route("licenseeUser")]
        public async Task<GetApiCallLogsForLicenseeUserResponse> GetApiCallLogsForLicenseeUser([FromUri] GetApiCallLogsRequest request)
        {
            int diffTimeZoneOffset = DateTimeOffset.Now.Offset.Hours - request.TimeZoneOffset;
            DateTime from = request.From.AddHours(diffTimeZoneOffset);
            DateTime to = request.To.AddDays(1).AddHours(diffTimeZoneOffset);

            var apiCallLogs =
                await
                    _apiCallLogQueries.GetApiCallLogsAsync(request.Ip, request.Path, request.RequestHeaders,
                        request.RequestContent, request.ResponseHeaders, request.ResponseContent, from, to);

            var apiCallLogModels = apiCallLogs.Select(apiCallLog => new ApiCallLogModel
            {
                Ip = apiCallLog.Ip,
                ExecutionTimeMs = apiCallLog.ExecutionTimeMs,
                Id = apiCallLog.Id,
                ThreadId = apiCallLog.ThreadId,
                Method = apiCallLog.Method,
                Path = apiCallLog.Path,
                Prefix = apiCallLog.Prefix,
                RecordedOn = apiCallLog.RecordedOn,
                ServerName = apiCallLog.ServerName,
                ResponseCode = apiCallLog.ResponseCode,
                ResponsePhrase = apiCallLog.ResponsePhrase,
            });

            return new GetApiCallLogsForLicenseeUserResponse
            {
                Valid = true,
                TotalCount = apiCallLogs.Count(),
                ApiCallLogs = apiCallLogModels.ToPagedList(request).ToArray()
            };
        }
    }
}