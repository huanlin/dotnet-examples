using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AFT.UGS.Core.Interfaces.ActionServices;
using AFT.UGS.Core.Interfaces.Commands;
using AFT.UGS.Core.Interfaces.Queries;
using AFT.UGS.Core.Interfaces.Queries.Paging;
using AFT.UGS.Core.Model;
using AFT.UGS.Core.Model.Enums;
using AFT.UGS.Core.Model.Services;
using AFT.UGS.Services.DataServices.Queries.Paging;
using AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages.Player;

namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api
{
    [RoutePrefix("api/players")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerQueries _playerQueries;
        private readonly IPlayerCommands _playerCommands;
        private readonly IPlayerActions _playerActions;

        public PlayerController(

            IPlayerQueries playerQueries, IPlayerCommands playerCommands, IPlayerActions playerActions, UserContext userContext)
            : base(userContext)
        {
            _playerQueries = playerQueries;
            _playerCommands = playerCommands;
            _playerActions = playerActions;
        }

        private PlayerModel ConvertToPlayerModel(Player player)
        {
            var brand = player.Brand;
            var licensee = brand == null ? null : brand.Licensee;

            return new PlayerModel
            {
                Id = player.Id,
                Username = player.Username,
                ExternalId = player.ExternalId,
                IpAddress = player.IpAddress,
                Tag = player.Tag,
                CultureCode = player.CultureCode,
                DefaultWalletId = player.DefaultWalletId,
                Currency = player.DefaultWallet == null ? String.Empty : player.DefaultWallet.Currency.Name,
                Balance = player.DefaultWallet == null ? 0 : player.DefaultWallet.Balance,
                BrandId = player.BrandId,
                BrandName = brand == null ? String.Empty : brand.Name,
                BrandStatusId = brand == null ? UgsStatus.Archived : brand.Status,
                BrandStatus = brand == null ? String.Empty : brand.Status.ToString(),
                LicenseeName = licensee == null ? String.Empty : licensee.Name,
                LicenseeStatusId = licensee == null ? UgsStatus.Archived : licensee.Status,
                LicenseeStatus = licensee == null ? String.Empty : licensee.Status.ToString(),
                StatusId = player.Status,
                Status = player.Status.ToString(),
                BetLimitGroupId = player.BetLimitGroupId,
                BetLimitGroupName = player.BetLimitGroup == null ? String.Empty : player.BetLimitGroup.Name,
                IsTestPlayer = player.IsTestPlayer,
                LastLoginUrl = player.LastLoginUrl,
                LastCashierUrl = player.LastCashierUrl,
                LastHelpUrl = player.LastHelpUrl,
                LastTermsUrl = player.LastTermsUrl,
                CreatedOn = player.CreatedOn
            };
        }

        private PlayerModel ConvertToPlayerModel(PlayerRecord player)
        {
            return new PlayerModel
            {
                Id = player.Id,
                Username = player.Username,
                ExternalId = player.ExternalId,
                IpAddress = player.IpAddress,
                Tag = player.Tag,
                CultureCode = player.CultureCode,
                DefaultWalletId = player.DefaultWalletId,
                Currency = player.DefaultWalletCurrencyName,
                Balance = player.DefaultWalletBalance ?? 0,
                BrandId = player.BrandId,
                BrandName = player.BrandName,
                BrandStatusId = player.BrandStatusId,
                BrandStatus = player.BrandStatusId.ToString(),
                LicenseeName = player.LicenseeName,
                LicenseeStatusId = player.LicenseeStatusId,
                LicenseeStatus = player.LicenseeStatusId.ToString(),
                StatusId = player.Status,
                Status = player.Status.ToString(),
                BetLimitGroupId = player.BetLimitGroupId,
                BetLimitGroupName = player.BetLimitGroupName,
                IsTestPlayer = player.IsTestPlayer,
                LastLoginUrl = player.LastLoginUrl,
                LastCashierUrl = player.LastCashierUrl,
                LastHelpUrl = player.LastHelpUrl,
                LastTermsUrl = player.LastTermsUrl,
                CreatedOn = player.CreatedOn
            };
        }

        private List<IFilterOption> BuildFilters(GetPlayersRequest request)
        {
            var filters = new List<IFilterOption>();

            if (!String.IsNullOrWhiteSpace(request.Username))
            {
                filters.Add(new FilterOption
                {
                    PropertyName = "Username",
                    Operator = FilterOperator.Contain,
                    Value = request.Username
                });
            }
            if (!String.IsNullOrWhiteSpace(request.BrandName))
            {
                filters.Add(new FilterOption
                {
                    PropertyName = "BrandName",
                    Operator = FilterOperator.Contain,
                    Value = request.BrandName
                });
            }
            if (!String.IsNullOrWhiteSpace(request.LicenseeName))
            {
                filters.Add(new FilterOption
                {
                    PropertyName = "LicenseeName",
                    Operator = FilterOperator.Contain,
                    Value = request.LicenseeName
                });
            }
            if (!String.IsNullOrWhiteSpace(request.Currency))
            {
                filters.Add(new FilterOption
                {
                    PropertyName = "DefaultWalletCurrencyCode",
                    Operator = FilterOperator.Equal,
                    Value = request.Currency
                });
            }
            return filters;
        }

        [HttpGet, Route]
        public async Task<GetPlayersResponse> GetPlayersAsync([FromUri]GetPlayersRequest request)
        {
            var pagableParam = new PagableQueryParameter
            {
                SortOption = new SortOption(request.SortBy, request.OrderBy.ToLower().Equals("desc")),
                FilterOptions = BuildFilters(request),
                Page = request.Page,
                PageSize = request.Rows
            };

            int totalCount = 0;
            var players = await _playerQueries.GetPlayersAsync(pagableParam, out totalCount);
            var playerModels = from p in players select ConvertToPlayerModel(p);

            return new GetPlayersResponse
            {
                Valid = true,
                TotalCount = totalCount,
                Players = playerModels.ToArray()
            };
        }

        [HttpGet, Route("{playerId:guid}")]
        public async Task<GetPlayerResponse> GetPlayerByIdAsync(Guid playerId)
        {
            var player = await _playerQueries.GetPlayerDetailByIdAsync(playerId);

            if (player == null)
            {
                return CreateInvalidResponse<GetPlayerResponse>(Resources.Player.PlayerNotFound);
            }

            player.DefaultWallet = await _playerQueries.GetWalletByIdAsync(player.DefaultWalletId);

            return new GetPlayerResponse
            {
                Valid = true,
                Player = ConvertToPlayerModel(player)
            };
        }

        [HttpPut, Route("{playerId:guid}/enable")]
        public async Task<EnablePlayerResponse> EnablePlayerAsync(Guid playerId)
        {
            var player = await _playerQueries.GetPlayerDetailByIdAsync(playerId);

            if (player == null)
            {
                return CreateInvalidResponse<EnablePlayerResponse>(Resources.Player.PlayerNotFound);
            }

            if (player.Status == PlayerStatus.Enabled)
            {
                return CreateInvalidResponse<EnablePlayerResponse>(Resources.Player.PlayerHasAlreadyBeenEnabled);
            }

            player.Status = PlayerStatus.Enabled;
            player.DefaultWallet = await _playerQueries.GetWalletByIdAsync(player.DefaultWalletId);

            await _playerCommands.UpdatePlayerAsync(player);
            return new EnablePlayerResponse
            {
                Valid = true,
                Player = ConvertToPlayerModel(player)
            };
        }

        [HttpPut, Route("{playerId:guid}/disable")]
        public async Task<DisablePlayerResponse> DisablePlayerAsync(Guid playerId)
        {
            var player = await _playerQueries.GetPlayerDetailByIdAsync(playerId);

            if (player == null)
            {
                return CreateInvalidResponse<DisablePlayerResponse>(Resources.Player.PlayerNotFound);
            }

            if (player.Status == PlayerStatus.Disabled)
            {
                return CreateInvalidResponse<DisablePlayerResponse>(Resources.Player.PlayerHasAlreadyBeenDisabled);
            }

            player.Status = PlayerStatus.Disabled;
            player.DefaultWallet = await _playerQueries.GetWalletByIdAsync(player.DefaultWalletId);

            await _playerCommands.UpdatePlayerAsync(player);
            return new DisablePlayerResponse
            {
                Valid = true,
                Player = ConvertToPlayerModel(player)
            };
        }

        [HttpPut, Route("{playerId:guid}/deauthorize")]
        public async Task<DeauthorizePlayerResponse> DeauthorizePlayerAsync(Guid playerId)
        {
            var player = await _playerQueries.GetPlayerDetailByIdAsync(playerId);

            if (player == null)
            {
                return CreateInvalidResponse<DeauthorizePlayerResponse>(Resources.Player.PlayerNotFound);
            }

            var count = await _playerActions.DisableTokensForPlayerAsync(player.ExternalId, player.BrandId, null);

            if (count > 0)
            {
                return new DeauthorizePlayerResponse
                {
                    Valid = true,
                    Message = Resources.Player.ThePlayerTokensAreDeauthorized
                };
            }

            return CreateInvalidResponse<DeauthorizePlayerResponse>(Resources.Player.NoTokenToDeauthorizePlayer);
        }
    }
}