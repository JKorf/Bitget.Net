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
        /// Assets transferred in
        /// </summary>
        [Map("transfer_in")]
        TransferIn,
        /// <summary>
        /// Assets transferred out
        /// </summary>
        [Map("transfer_out")]
        TransferOut,
        /// <summary>
        /// Borrow
        /// </summary>
        [Map("borrow")]
        Borrow,
        /// <summary>
        /// Repay
        /// </summary>
        [Map("repay")]
        Repay,
        /// <summary>
        /// Liquidation fee
        /// </summary>
        [Map("liquidation_fee")]
        LiquidationFee,
        /// <summary>
        /// Collateral shortfall compensation from risk fund
        /// </summary>
        [Map("compensate")]
        Compensate,
        /// <summary>
        /// Trade and deposit (buy
        /// </summary>
        [Map("deal_in")]
        DealIn,
        /// <summary>
        /// Trade and withdraw (sell
        /// </summary>
        [Map("deal_out")]
        DealOut,
        /// <summary>
        /// Deduction for collateral shortfall
        /// </summary>
        [Map("confiscated")]
        Confiscated,
        /// <summary>
        /// Exchange income, charged from the system account
        /// </summary>
        [Map("exchange_in")]
        ExchangeIn,
        /// <summary>
        /// Exchange expense, charged to the system account
        /// </summary>
        [Map("exchange_out")]
        ExchangeOut,
        /// <summary>
        /// Exchange income of the system account, with exchange expense appearing at the same time
        /// </summary>
        [Map("sys_exchange_in")]
        SysExchangeIn,
        /// <summary>
        /// Exchange expense of the system account, with exchange income appearing at the same time
        /// </summary>
        [Map("sys_exchange_out")]
        SysExchangeOut,
    }

}
