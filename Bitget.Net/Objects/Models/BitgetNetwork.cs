using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Network info
    /// </summary>
    public class BitgetNetwork
    {
        /// <summary>
        /// Network name
        /// </summary>
        [JsonProperty("chain")]
        public string? Name { get; set; }
        /// <summary>
        /// Whether tag is needed
        /// </summary>
        [JsonProperty("needTag")]
        public bool NeedTag { get; set; }
        /// <summary>
        /// Whether it is possible to withdraw
        /// </summary>
        [JsonProperty("withdrawable")]
        public bool Withdrawable { get; set; }
        /// <summary>
        /// Wheter it is possible to deposit
        /// </summary>
        [JsonProperty("rechargeable")]
        public bool Depositable { get; set; }
        /// <summary>
        /// Withdraw fee
        /// </summary>
        [JsonProperty("withdrawFee")]
        public decimal WithdrawFee { get; set; }
        /// <summary>
        /// Deposit confirmations required
        /// </summary>
        [JsonProperty("depositConfirm")]
        public decimal DepositConfirmations { get; set; }
        /// <summary>
        /// Withdraw confirmations required
        /// </summary>
        [JsonProperty("withdrawConfirm")]
        public decimal WithdrawConfimations { get; set; }
        /// <summary>
        /// Min deposit quantity
        /// </summary>
        [JsonProperty("minDepositAmount")]
        public decimal MinDepositQuantity { get; set; }
        /// <summary>
        /// Min withdrawal quantity
        /// </summary>
        [JsonProperty("minWithdrawAmount")]
        public decimal MinWithdrawQuantity { get; set; }
        /// <summary>
        /// Explorer url
        /// </summary>
        [JsonProperty("browserUrl")]
        public string? Url { get; set; }
    }
}
