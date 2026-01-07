using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Business type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BusinessType>))]
    public enum BusinessType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// Withdraw
        /// </summary>
        [Map("withdraw")]
        Withdraw,
        /// <summary>
        /// Buy
        /// </summary>
        [Map("buy")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("sell")]
        Sell,
        /// <summary>
        /// Deduction of spot trading transaction fee
        /// </summary>
        [Map("deduction of handling fee", "DEDUCTION_HANDLING_FEE")]
        FeeDeduction,
        /// <summary>
        /// Transfer-in
        /// </summary>
        [Map("transfer-in", "TRANSFER_IN")]
        TransferIn,
        /// <summary>
        /// Transfer-out
        /// </summary>
        [Map("transfer-out", "TRANSFER_OUT")]
        TransferOut,
        /// <summary>
        /// Rebate
        /// </summary>
        [Map("rebate rewards")]
        RebateRewards,
        /// <summary>
        /// Airdrop rewards
        /// </summary>
        [Map("airdrop rewards")]
        AirdropRewards,
        /// <summary>
        /// USDT futures promotion rewards
        /// </summary>
        [Map("USDT contract rewards")]
        UsdtContractRewards,
        /// <summary>
        /// Mix contract promotion rewards
        /// </summary>
        [Map("mix contract rewards")]
        MixContractRewards,
        /// <summary>
        /// System lock-up
        /// </summary>
        [Map("system lock")]
        SystemLock,
        /// <summary>
        /// User lock-up
        /// </summary>
        [Map("user lock")]
        UserLock,
        /// <summary>
        /// Inner address withdraw in
        /// </summary>
        [Map("INNER_ADDRESS_WITHDRAW_IN")]
        InnerAddressWithdrawIn,
        /// <summary>
        /// Order exchange in
        /// </summary>
        [Map("ORDER_EXCHANGE_IN")]
        OrderExchangeIn,
        /// <summary>
        /// Order exchange out
        /// </summary>
        [Map("ORDER_EXCHANGE_OUT")]
        OrderExchangeOut,
        /// <summary>
        /// Activity asset reward user in
        /// </summary>
        [Map("ACTIVITY_ASSET_REWARD_USER_IN")]
        ActivityAssetRewardUserIn,
        /// <summary>
        /// Small exchange user in
        /// </summary>
        [Map("SMALL_EXCHANGE_USER_IN")]
        SmallExchangeUserIn,
        /// <summary>
        /// Small exchange user out
        /// </summary>
        [Map("SMALL_EXCHANGE_USER_OUT")]
        SmallExchangeUserOut
    }
}
