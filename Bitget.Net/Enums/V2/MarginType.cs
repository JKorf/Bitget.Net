using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Margin type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MarginType>))]
    public enum MarginType
    {
        /// <summary>
        /// ["<c>transfer_in</c>"] Assets transferred in
        /// </summary>
        [Map("transfer_in")]
        TransferIn,
        /// <summary>
        /// ["<c>transfer_out</c>"] Assets transferred out
        /// </summary>
        [Map("transfer_out")]
        TransferOut,
        /// <summary>
        /// ["<c>borrow</c>"] Borrow
        /// </summary>
        [Map("borrow")]
        Borrow,
        /// <summary>
        /// ["<c>repay</c>"] Repay
        /// </summary>
        [Map("repay")]
        Repay,
        /// <summary>
        /// ["<c>liquidation_fee</c>"] Liquidation fee
        /// </summary>
        [Map("liquidation_fee")]
        LiquidationFee,
        /// <summary>
        /// ["<c>compensate</c>"] Collateral shortfall compensation from risk fund
        /// </summary>
        [Map("compensate")]
        Compensate,
        /// <summary>
        /// ["<c>deal_in</c>"] Trade and deposit (buy
        /// </summary>
        [Map("deal_in")]
        DealIn,
        /// <summary>
        /// ["<c>deal_out</c>"] Trade and withdraw (sell
        /// </summary>
        [Map("deal_out")]
        DealOut,
        /// <summary>
        /// ["<c>confiscated</c>"] Deduction for collateral shortfall
        /// </summary>
        [Map("confiscated")]
        Confiscated,
        /// <summary>
        /// ["<c>exchange_in</c>"] Exchange income, charged from the system account
        /// </summary>
        [Map("exchange_in")]
        ExchangeIn,
        /// <summary>
        /// ["<c>exchange_out</c>"] Exchange expense, charged to the system account
        /// </summary>
        [Map("exchange_out")]
        ExchangeOut,
        /// <summary>
        /// ["<c>sys_exchange_in</c>"] Exchange income of the system account, with exchange expense appearing at the same time
        /// </summary>
        [Map("sys_exchange_in")]
        SysExchangeIn,
        /// <summary>
        /// ["<c>sys_exchange_out</c>"] Exchange expense of the system account, with exchange income appearing at the same time
        /// </summary>
        [Map("sys_exchange_out")]
        SysExchangeOut,
    }

}
