using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Biz type
    /// </summary>
    public enum BizType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// Withdrawal
        /// </summary>
        [Map("withdrawal")]
        Withdrawal,
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
        /// Deduction of handling fee
        /// </summary>
        [Map("deduction of handling fee")]
        DeductionFeeHandling,
        /// <summary>
        /// Transfer in
        /// </summary>
        [Map("transfer-in")]
        TransferIn,
        /// <summary>
        /// Transfer out
        /// </summary>
        [Map("transfer-out")]
        TransferOut,
        /// <summary>
        /// Rebate rewards
        /// </summary>
        [Map("rebate rewards")]
        RebateRewards,
        /// <summary>
        /// Airdrop rewards
        /// </summary>
        [Map("airdrop rewards")]
        AirdropRewards,
        /// <summary>
        /// Usdt contract rewards
        /// </summary>
        [Map("USDT contract rewards")]
        UsdtContractRewards,
        /// <summary>
        /// Mix contract rewards
        /// </summary>
        [Map("mix contract rewards")]
        MixContractRewards,
        /// <summary>
        /// System lock
        /// </summary>
        [Map("System lock")]
        SystemLock,
        /// <summary>
        /// User lock
        /// </summary>
        [Map("User lock")]
        UserLock
    }
}
