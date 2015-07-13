using System.Threading.Tasks;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;

namespace AFT.UGS.Core.Interfaces.Queries
{
    public interface ITransactionQueries
    {
        Task<Transaction[]> GetTransactionsAsync(IPagableQueryParameter queryParam, out int totalCount);
    }
}