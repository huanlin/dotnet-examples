using System.Threading.Tasks;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;

namespace AFT.UGS.Core.Interfaces.Queries
{
    public interface IApiCallLogQueries
    {
        Task<ApiCallLog[]> GetApiCallLogsAsync(IPagableQueryParameter queryParam, out int totalCount);
    }
}