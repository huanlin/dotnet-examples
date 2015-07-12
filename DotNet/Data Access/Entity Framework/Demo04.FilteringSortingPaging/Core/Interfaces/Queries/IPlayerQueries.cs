using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;
using AFT.UGS.Core.Model.Services;

namespace AFT.UGS.Core.Interfaces.Queries
{
    public interface IPlayerQueries
    {
        Task<Player> GetPlayerByIdAsync(Guid playerId, Func<IDbSet<Player>, IQueryable<Player>> preQuery = null);
        Task<Player> GetPlayerDetailByIdAsync(Guid playerId);

        Task<Player> GetPlayerByExternalIdAsync(Guid brandId, string externalId, Func<IDbSet<Player>, IQueryable<Player>> preQuery = null);

        Task<string> GetGameProviderBetLimitCodeAsync(Guid gameProviderId, string currencyCode, int betLimitGroupId);

        Task<List<int>> GetBetLimitCodesForBrandAsync(Guid brandId);

        Task<Guid> GetBrandIdByPlayerIdAsync(Guid playerId);

        Task<Wallet> GetWalletByIdAsync(Guid walletId);

        Task<Player[]> GetPlayersAsync();
        Task<PlayerRecord[]> GetPlayersAsync(IPagableQueryParameter queryParam, out int totalCount);

        Task<Player[]> GetPlayersForLicenseeAsync(Guid licenseeId);
        Task<Player[]> GetPlayersForBrandAsync(Guid brandId);
        Task<Player[]> GetPlayersByUsernameAsync(string username);
        Task<Licensee[]> GetLicensees();
        Task<Brand[]> GetBrandsForLicensee(Guid licenseeId);
    }
}