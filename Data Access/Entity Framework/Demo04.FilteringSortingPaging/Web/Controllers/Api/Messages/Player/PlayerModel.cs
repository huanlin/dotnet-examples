using System;
using AFT.UGS.Core.Model.Enums;

namespace AFT.UGS.Web.UgsBackendWebsite.Controllers.Api.Messages.Player
{
    public class PlayerModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ExternalId { get; set; }
        public string IpAddress { get; set; }
        public string Tag { get; set; }
        public string CultureCode { get; set; }
        public Guid? DefaultWalletId { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public UgsStatus BrandStatusId { get; set; }
        public string BrandStatus { get; set; }
        public string LicenseeName { get; set; }
        public UgsStatus LicenseeStatusId { get; set; }
        public string LicenseeStatus { get; set; }
        public PlayerStatus StatusId { get; set; }
        public string Status { get; set; }
        public int BetLimitGroupId { get; set; }
        public string BetLimitGroupName { get; set; }
        public bool IsTestPlayer { get; set; }
        public string LastLoginUrl { get; set; }
        public string LastCashierUrl { get; set; }
        public string LastHelpUrl { get; set; }
        public string LastTermsUrl { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public TokenModel[] Tokens { get; set; }
        public WalletModel[] Wallets { get; set; }
    }
}