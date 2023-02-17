using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AFT.UGS.Core.Interfaces.Data;
using AFT.UGS.Core.Interfaces.Extensions;
using AFT.UGS.Core.Interfaces.Queries;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;
using AFT.UGS.Services.DataServices.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries
{
    public sealed class ApiCallLogQueries : IApiCallLogQueries
    {
        private readonly IPlayerRepository _repository;

        public ApiCallLogQueries(IPlayerRepository playerRepo)
        {
            _repository = playerRepo;
        }

        Task<ApiCallLog[]> IApiCallLogQueries.GetApiCallLogsAsync(IPagableQueryParameter queryParam, out int totalCount)
        {
            var filter = (ApiCallLogFilter) queryParam.Filter;

            var apiCallLogs = _repository.ApiCallLogs.Where(a => a.RecordedOn >= filter.From && a.RecordedOn <= filter.To)
                .Where(filter.Ip, a => a.Ip.Contains(filter.Ip))
                .Where(filter.Path, a => a.Path.Contains(filter.Path))
                .Where(filter.RequestHeaders, a => a.RequestHeaders.Contains(filter.RequestHeaders))
                .Where(filter.RequestContent, a => a.RequestContent.Contains(filter.RequestContent))
                .Where(filter.ResponseHeaders, a => a.ResponseHeaders.Contains(filter.ResponseHeaders))
                .Where(filter.ResponseContent, a => a.ResponseContent.Contains(filter.ResponseContent))
                .OrderBy(queryParam.SortOption)
                .AsNoTracking()
                .ToPagedArray(queryParam.Page, queryParam.PageSize, out totalCount);

            return Task.FromResult(apiCallLogs);
        }

        public class ApiCallLogFilter : IFilter
        {
            public string Ip { get; set; }

            public string Path { get; set; }

            public string RequestHeaders { get; set; }

            public string RequestContent { get; set; }

            public string ResponseHeaders { get; set; }

            public string ResponseContent { get; set; }

            public DateTime From { get; set; }

            public DateTime To { get; set; }
        }
    }
}