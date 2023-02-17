using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AFT.UGS.Core.Interfaces.Data;
using AFT.UGS.Core.Interfaces.Extensions;
using AFT.UGS.Core.Interfaces.Queries;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;
using AFT.UGS.Core.Model.Enums;
using AFT.UGS.Core.Model.Services;
using AFT.UGS.Services.DataServices.Queries.Paging;

namespace AFT.UGS.Services.DataServices.Queries
{
    public sealed class PlayerQueries : IPlayerQueries
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IBrandRepository _brandRepo;

        public PlayerQueries(IPlayerRepository playerRepo, IBrandRepository brandRepo)
        {
            _playerRepo = playerRepo;
            _brandRepo = brandRepo;
        }

        Task<Player> IPlayerQueries.GetPlayerByIdAsync(
            Guid playerId, Func<IDbSet<Player>, IQueryable<Player>> preQuery)
        {
            if (preQuery == null) preQuery = c => c;
            return
                preQuery(_playerRepo.Players)
                    .FirstOrDefaultAsync(p => p.Id == playerId);
        }

        Task<Player> IPlayerQueries.GetPlayerByExternalIdAsync(
            Guid brandId, string externalId,
            Func<IDbSet<Player>, IQueryable<Player>> preQuery)
        {
            if (preQuery == null) preQuery = c => c;
            return
                preQuery(_playerRepo.Players)
                    .FirstOrDefaultAsync(p => p.BrandId == brandId && p.ExternalId == externalId);
        }

        Task<string> IPlayerQueries.GetGameProviderBetLimitCodeAsync(
            Guid gameProviderId, string currencyCode, int betLimitGroupId)
        {
            return
                _playerRepo.GameProviderBetLimits
                .Where(gpbl => gpbl.GameProviderId == gameProviderId &&
                               gpbl.CurrencyCode == currencyCode &&
                               gpbl.BetLimitGroupId == betLimitGroupId)
                .Select(gpbl => gpbl.Code)
                .FirstOrDefaultAsync();
        }

        Task<List<int>> IPlayerQueries.GetBetLimitCodesForBrandAsync(Guid brandId)
        {
            return
                _brandRepo.Brands
                    .Include(b => b.BetLimitGroups)
                    .Where(b => b.Id == brandId)
                    .SelectMany(b => b.BetLimitGroups)
                    .Select(blg => blg.Id)
                    .ToListAsync();
        }

        Task<Guid> IPlayerQueries.GetBrandIdByPlayerIdAsync(Guid playerId)
        {
            return
                _playerRepo.Players
                    .Where(p => p.Id == playerId)
                    .Select(p => p.BrandId)
                    .FirstOrDefaultAsync();
        }

        Task<Wallet> IPlayerQueries.GetWalletByIdAsync(Guid walletId)
        {
            return _playerRepo.Wallets
                .Include(w => w.Currency)
                .SingleOrDefaultAsync(w => w.Id == walletId);
        }

        public Task<Player> GetPlayerDetailByIdAsync(Guid playerId)
        {
            return
                _playerRepo.Players
                    .Where(p => p.Id == playerId)
                    .Include(p => p.Tokens)
                    .Include(p => p.Brand)
                    .Include(p => p.Brand.Licensee)
                    .Include(p => p.BetLimitGroup)
                    .Include(p => p.Wallets)
                    .SingleOrDefaultAsync();
        }

        Task<Player[]> IPlayerQueries.GetPlayersAsync()
        {
            return _playerRepo.Players
                .Include(p => p.Brand)
                .Include(p => p.Brand.Licensee)
                .Include(p => p.BetLimitGroup)
                .Include(p => p.Wallets)
                .ToArrayAsync();
        }

        Task<PlayerRecord[]> IPlayerQueries.GetPlayersAsync(IPagableQueryParameter queryParam, out int totalCount)
        {
            var query = from p in _playerRepo.Players
                        join w in _playerRepo.Wallets on p.DefaultWalletId equals w.Id
                        join b in _brandRepo.Brands on p.BrandId equals b.Id
                        join l in _brandRepo.Licensees on b.LicenseeId equals l.Id
                        join blg in _playerRepo.BetLimitGroups on p.BetLimitGroupId equals blg.Id
                        join c in _brandRepo.Currencies on w.CurrencyCode equals c.Code
                        select new PlayerRecord
                        {
                            Id = p.Id,
                            Username = p.Username,
                            ExternalId = p.ExternalId,
                            IpAddress = p.IpAddress,
                            Tag = p.Tag,
                            CultureCode = p.CultureCode,
                            DefaultWalletId = p.DefaultWalletId,
                            BrandId = p.BrandId,
                            CreatedOn = p.CreatedOn,
                            Status = p.Status,
                            BetLimitGroupId = p.BetLimitGroupId,
                            IsTestPlayer = p.IsTestPlayer,
                            LastCashierUrl = p.LastCashierUrl,
                            LastHelpUrl = p.LastHelpUrl,
                            LastLoginUrl = p.LastLoginUrl,
                            LastTermsUrl = p.LastTermsUrl,
                            DefaultWalletCurrencyCode = w.CurrencyCode,
                            DefaultWalletCurrencyName = c.Name,
                            DefaultWalletBalance = w.Balance,
                            BrandName = b.Name,
                            BrandStatusId = b.Status,
                            LicenseeName = l.Name,
                            LicenseeStatusId = l.Status,
                            BetLimitGroupName = blg.Name
                        };

            query = query.Where(queryParam.FilterOptions)
                         .OrderBy(queryParam.SortOption)
                         .AsNoTracking();

            var players = query.ToPagedArray(queryParam.Page, queryParam.PageSize, out totalCount);

            return Task.FromResult(players);
        }

        Task<Player[]> IPlayerQueries.GetPlayersForLicenseeAsync(Guid licenseeId)
        {
            var query =
                from p in _playerRepo.Players
                join b in _brandRepo.Brands on p.BrandId equals b.Id
                join l in _brandRepo.Licensees on b.LicenseeId equals l.Id
                where l.Id == licenseeId
                select p;

            return query
                .Include(p => p.Tokens)
                .Include(p => p.Wallets)
                .ToArrayAsync();
        }

        Task<Player[]> IPlayerQueries.GetPlayersForBrandAsync(Guid brandId)
        {
            return _playerRepo.Players
                .Include(p => p.Tokens)
                .Include(p => p.Wallets)
                .Where(p => p.BrandId == brandId).ToArrayAsync();
        }

        Task<Player[]> IPlayerQueries.GetPlayersByUsernameAsync(string username)
        {
            return _playerRepo.Players
                .Include(p => p.Tokens)
                .Include(p => p.Wallets)
                .Where(p => p.Username.Contains(username)).ToArrayAsync();
        }

        public Task<Licensee[]> GetLicensees()
        {
            return _brandRepo.Licensees
                .Where(l => l.Status != UgsStatus.Archived)
                .ToArrayAsync();
        }

        public Task<Brand[]> GetBrandsForLicensee(Guid licenseeId)
        {
            return _brandRepo.Brands
                .Where(b => b.LicenseeId == licenseeId)
                .ToArrayAsync();
        }
    }
}