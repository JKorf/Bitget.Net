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
        /// ["<c>deposit</c>"] Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// ["<c>withdraw</c>"] Withdraw
        /// </summary>
        [Map("withdraw")]
        Withdraw,
        /// <summary>
        /// ["<c>buy</c>"] Buy
        /// </summary>
        [Map("buy")]
        Buy,
        /// <summary>
        /// ["<c>sell</c>"] Sell
        /// </summary>
        [Map("sell")]
        Sell,
        /// <summary>
        /// ["<c>deduction of handling fee</c>"] Deduction of spot trading transaction fee
        /// </summary>
        [Map("deduction of handling fee", "DEDUCTION_HANDLING_FEE")]
        FeeDeduction,
        /// <summary>
        /// ["<c>transfer-in</c>"] Transfer-in
        /// </summary>
        [Map("transfer-in", "TRANSFER_IN")]
        TransferIn,
        /// <summary>
        /// ["<c>transfer-out</c>"] Transfer-out
        /// </summary>
        [Map("transfer-out", "TRANSFER_OUT")]
        TransferOut,
        /// <summary>
        /// ["<c>rebate rewards</c>"] Rebate
        /// </summary>
        [Map("rebate rewards", "REBATE_REWARDS")]
        RebateRewards,
        /// <summary>
        /// ["<c>airdrop rewards</c>"] Airdrop rewards
        /// </summary>
        [Map("airdrop rewards")]
        AirdropRewards,
        /// <summary>
        /// ["<c>USDT contract rewards</c>"] USDT futures promotion rewards
        /// </summary>
        [Map("USDT contract rewards")]
        UsdtContractRewards,
        /// <summary>
        /// ["<c>mix contract rewards</c>"] Mix contract promotion rewards
        /// </summary>
        [Map("mix contract rewards")]
        MixContractRewards,
        /// <summary>
        /// ["<c>system lock</c>"] System lock-up
        /// </summary>
        [Map("system lock")]
        SystemLock,
        /// <summary>
        /// ["<c>user lock</c>"] User lock-up
        /// </summary>
        [Map("user lock")]
        UserLock,
        /// <summary>
        /// ["<c>INNER_ADDRESS_WITHDRAW_IN</c>"] Inner address withdraw in
        /// </summary>
        [Map("INNER_ADDRESS_WITHDRAW_IN")]
        InnerAddressWithdrawIn,
        /// <summary>
        /// ["<c>ORDER_EXCHANGE_IN</c>"] Order exchange in
        /// </summary>
        [Map("ORDER_EXCHANGE_IN")]
        OrderExchangeIn,
        /// <summary>
        /// ["<c>ORDER_EXCHANGE_OUT</c>"] Order exchange out
        /// </summary>
        [Map("ORDER_EXCHANGE_OUT")]
        OrderExchangeOut,
        /// <summary>
        /// ["<c>ACTIVITY_ASSET_REWARD_USER_IN</c>"] Activity asset reward user in
        /// </summary>
        [Map("ACTIVITY_ASSET_REWARD_USER_IN")]
        ActivityAssetRewardUserIn,
        /// <summary>
        /// ["<c>SMALL_EXCHANGE_USER_IN</c>"] Small exchange user in
        /// </summary>
        [Map("SMALL_EXCHANGE_USER_IN")]
        SmallExchangeUserIn,
        /// <summary>
        /// ["<c>SMALL_EXCHANGE_USER_OUT</c>"] Small exchange user out
        /// </summary>
        [Map("SMALL_EXCHANGE_USER_OUT")]
        SmallExchangeUserOut
    }
}
