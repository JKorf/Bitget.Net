using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Asset info
    /// </summary>
    [SerializationModel]
    public record BitgetAsset
    {
        /// <summary>
        /// ["<c>coinId</c>"] Asset id
        /// </summary>
        [JsonPropertyName("coinId")]
        public string AssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>coin</c>"] Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>transfer</c>"] Is the asset transferable
        /// </summary>
        [JsonPropertyName("transfer")]
        public bool Transferable { get; set; }

        /// <summary>
        /// ["<c>areaCoin</c>"] Is the asset area restricted
        /// </summary>
        [JsonPropertyName("areaCoin")]
        public bool AreaAsset { get; set; }

        /// <summary>
        /// ["<c>chains</c>"] Supported networks
        /// </summary>
        [JsonPropertyName("chains")]
        public BitgetAssetNetwork[] Networks { get; set; } = Array.Empty<BitgetAssetNetwork>();
    }

    /// <summary>
    /// Network info
    /// </summary>
    [SerializationModel]
    public record BitgetAssetNetwork
    {
        /// <summary>
        /// ["<c>chain</c>"] Network name
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>needTag</c>"] Whether a tag is needed for withdrawals
        /// </summary>
        [JsonPropertyName("needTag")]
        public bool NeedsTag { get; set; }
        /// <summary>
        /// ["<c>withdrawable</c>"] Whether the asset is withdrawable
        /// </summary>
        [JsonPropertyName("withdrawable")]
        public bool Withdrawable { get; set; }
        /// <summary>
        /// ["<c>rechargeable</c>"] Whether the asset is depositable
        /// </summary>
        [JsonPropertyName("rechargeable")]
        public bool Depositable { get; set; }
        /// <summary>
        /// ["<c>withdrawFee</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("withdrawFee")]
        public decimal WithdrawFee { get; set; }
        /// <summary>
        /// ["<c>extraWithdrawFee</c>"] Extra withdrawal fee
        /// </summary>
        [JsonPropertyName("extraWithdrawFee")]
        public decimal ExtraWithdrawFee { get; set; }
        /// <summary>
        /// ["<c>depositConfirm</c>"] Deposit confirmations needed
        /// </summary>
        [JsonPropertyName("depositConfirm"), JsonConverter(typeof(IntConverter))]
        public int? DepositConfirm { get; set; }
        /// <summary>
        /// ["<c>withdrawConfirm</c>"] Withdrawal confirmations
        /// </summary>
        [JsonPropertyName("withdrawConfirm"), JsonConverter(typeof(IntConverter))]
        public int? WithdrawConfirm { get; set; }
        /// <summary>
        /// ["<c>minDepositAmount</c>"] Minimal deposit quantity
        /// </summary>
        [JsonPropertyName("minDepositAmount")]
        public decimal MinDepositQuantity { get; set; }
        /// <summary>
        /// ["<c>minWithdrawAmount</c>"] Minimal withdrawal quantity
        /// </summary>
        [JsonPropertyName("minWithdrawAmount")]
        public decimal MinWithdrawQuantity { get; set; }
        /// <summary>
        /// ["<c>browserUrl</c>"] Browser url
        /// </summary>
        [JsonPropertyName("browserUrl")]
        public string? BrowserUrl { get; set; }
        /// <summary>
        /// ["<c>contractAddress</c>"] Contract address
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string? ContractAddress { get; set; }
        /// <summary>
        /// ["<c>withdrawStep</c>"] If not null, withdrawal quantities should be a multiple of this
        /// </summary>
        [JsonPropertyName("withdrawStep")]
        public decimal WithdrawQuantityStep { get; set; }
        /// <summary>
        /// ["<c>withdrawMinScale</c>"] Decimal places of withdrawal quantity
        /// </summary>
        [JsonPropertyName("withdrawMinScale"), JsonConverter(typeof(IntConverter))]
        public int? WithdrawQuantityPrecision { get; set; }

        /// <summary>
        /// ["<c>congestion</c>"] Congestion levels
        /// </summary>
        [JsonPropertyName("congestion")]
        public string Congestion { get; set; } = string.Empty;
    }
}
