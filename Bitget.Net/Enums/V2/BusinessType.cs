using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Business type
    /// </summary>
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
        [Map("deduction of handling fee")]
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
        InnerAddressWithdrawIn
    }
}
