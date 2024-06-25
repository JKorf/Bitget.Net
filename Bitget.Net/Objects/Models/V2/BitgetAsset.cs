using Bitget.Net.Converters;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Asset info
    /// </summary>
    public record BitgetAsset
    {
        /// <summary>
        /// Asset id
        /// </summary>
        [JsonPropertyName("coinId")]
        public string AssetId { get; set; } = string.Empty;

        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Is the asset transferable
        /// </summary>
        [JsonPropertyName("transfer")]
        public bool Transferable { get; set; }

        /// <summary>
        /// Supported networks
        /// </summary>
        [JsonPropertyName("chains")]
        public IEnumerable<BitgetAssetNetwork> Networks { get; set; } = Array.Empty<BitgetAssetNetwork>();
    }

    /// <summary>
    /// Network info
    /// </summary>
    public record BitgetAssetNetwork
    {
        /// <summary>
        /// Network name
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Whether a tag is needed for withdrawals
        /// </summary>
        [JsonPropertyName("needTag")]
        public bool NeedsTag { get; set; }
        /// <summary>
        /// Whether the asset is withdrawable
        /// </summary>
        [JsonPropertyName("withdrawable")]
        public bool Withdrawable { get; set; }
        /// <summary>
        /// Whether the asset is depositable
        /// </summary>
        [JsonPropertyName("rechargeable")]
        public bool Depositable { get; set; }
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        [JsonPropertyName("withdrawFee")]
        public decimal WithdrawFee { get; set; }
        /// <summary>
        /// Extra withdrawal fee
        /// </summary>
        [JsonPropertyName("extraWithdrawFee")]
        public decimal ExtraWithdrawFee { get; set; }
        /// <summary>
        /// Deposit confirmations needed
        /// </summary>
        [JsonPropertyName("depositConfirm"), JsonConverter(typeof(IntConverter))]
        public int? DepositConfirm { get; set; }
        /// <summary>
        /// Withdrawal confirmations
        /// </summary>
        [JsonPropertyName("withdrawConfirm"), JsonConverter(typeof(IntConverter))]
        public int? WithdrawConfirm { get; set; }
        /// <summary>
        /// Minimal deposit quantity
        /// </summary>
        [JsonPropertyName("minDepositAmount")]
        public decimal MinDepositQuantity { get; set; }
        /// <summary>
        /// Minimal withdrawal quantity
        /// </summary>
        [JsonPropertyName("minWithdrawAmount")]
        public decimal MinWithdrawQuantity { get; set; }
        /// <summary>
        /// Browser url
        /// </summary>
        [JsonPropertyName("browserUrl")]
        public string? BrowserUrl { get; set; }
        /// <summary>
        /// Contract address
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string? ContractAddress { get; set; }
        /// <summary>
        /// If not null, withdrawal quantities should be a multiple of this
        /// </summary>
        [JsonPropertyName("withdrawStep")]
        public decimal WithdrawQuantityStep { get; set; }
        /// <summary>
        /// Decimal places of withdrawal quantity
        /// </summary>
        [JsonPropertyName("withdrawMinScale"), JsonConverter(typeof(IntConverter))]
        public int? WithdrawQuantityPrecision { get; set; }
    }
}
