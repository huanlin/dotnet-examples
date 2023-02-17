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
    public sealed class TransactionQueries : ITransactionQueries
    {
        private readonly IPlayerRepository _playerRepo;

        public TransactionQueries(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        Task<Transaction[]> ITransactionQueries.GetTransactionsAsync(IPagableQueryParameter queryParam, out int totalCount)
        {
            var filter = queryParam.Filter as TransactionFilter;
            var transactions = _playerRepo.Transactions
                .Include(t => t.Wallet)
                .Include(t => t.Wallet.Currency)
                .Include(t => t.Wallet.Player)
                .Where(t => t.Wallet.Player.Id == filter.PlayerId)
                .Where(filter.TransactionId, t => t.Id == filter.TransactionId)
                .Where(filter.ExternalTransactionId, a => a.ExternalTransactionId == filter.ExternalTransactionId)
                .Where(filter.ExternalBatchId, a => a.ExternalBatchId == filter.ExternalBatchId)
                .OrderBy(queryParam.SortOption)
                .AsNoTracking()
                .ToPagedArray(queryParam.Page, queryParam.PageSize, out totalCount);

            return Task.FromResult(transactions);
        }

        public class TransactionFilter : IFilter
        {
            public Guid PlayerId { get; set; }

            public Guid? TransactionId { get; set; }

            public string ExternalTransactionId { get; set; }

            public string ExternalBatchId { get; set; }
        }
    }
}