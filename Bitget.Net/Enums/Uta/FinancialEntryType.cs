using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

using System.Text.Json.Serialization;

/// <summary>
/// Financial entry type
/// </summary>
[JsonConverter(typeof(EnumConverter<FinancialEntryType>))]
public enum FinancialEntryType
{
    /// <summary>
    /// Transfer in
    /// </summary>
    [Map("TRANSFER_IN")]
    TransferIn,
    /// <summary>
    /// Transfer out
    /// </summary>
    [Map("TRANSFER_OUT")]
    TransferOut,
    /// <summary>
    /// Auto borrow system debit
    /// </summary>
    [Map("CONVERSION_UPON_DELISTING")]
    ConversionUponDelisting,
    /// <summary>
    /// Order dealt fund out
    /// </summary>
    [Map("ORDER_DEALT_FROZEN_OUT")]
    OrderDealtFrozenOut,
    /// <summary>
    /// Order dealt fund in
    /// </summary>
    [Map("ORDER_DEALT_IN")]
    OrderDealtIn,
    /// <summary>
    /// Trading fee deduction
    /// </summary>
    [Map("ORDER_PLF_FEE_OUT")]
    OrderPlfFeeOut,
    /// <summary>
    /// Repayment exchange out
    /// </summary>
    [Map("EXCHANGE_SOURCE_TOKEN_USER_OUT")]
    ExchangeSourceTokenUserOut,
    /// <summary>
    /// Repayment exchange in
    /// </summary>
    [Map("EXCHANGE_TARGET_TOKEN_USER_IN")]
    ExchangeTargetTokenUserIn,
    /// <summary>
    /// Open long position
    /// </summary>
    [Map("OPEN_LONG")]
    OpenLong,
    /// <summary>
    /// Open short position
    /// </summary>
    [Map("OPEN_SHORT")]
    OpenShort,
    /// <summary>
    /// Single-sided buy
    /// </summary>
    [Map("BUY_DEAL")]
    BuyDeal,
    /// <summary>
    /// Single-sided sell
    /// </summary>
    [Map("SELL_DEAL")]
    SellDeal,
    /// <summary>
    /// Close long
    /// </summary>
    [Map("CLOSE_LONG")]
    CloseLong,
    /// <summary>
    /// Close short
    /// </summary>
    [Map("CLOSE_SHORT")]
    CloseShort,
    /// <summary>
    /// Forced reduction of long position
    /// </summary>
    [Map("FORCE_CLOSE_LONG")]
    ForceCloseLong,
    /// <summary>
    /// Forced reduction of short position
    /// </summary>
    [Map("FORCE_CLOSE_SHORT")]
    ForceCloseShort,
    /// <summary>
    /// Liquidate long position
    /// </summary>
    [Map("BURST_CLOSE_LONG")]
    BurstCloseLong,
    /// <summary>
    /// Liquidate short position
    /// </summary>
    [Map("BURST_CLOSE_SHORT")]
    BurstCloseShort,
    /// <summary>
    /// Offset close long
    /// </summary>
    [Map("OFFSET_REDUCE_CLOSE_LONG")]
    OffsetReduceCloseLong,
    /// <summary>
    /// Offset close short
    /// </summary>
    [Map("OFFSET_REDUCE_CLOSE_SHORT")]
    OffsetReduceCloseShort,
    /// <summary>
    /// Forced buy
    /// </summary>
    [Map("FORCE_BUY_SSM")]
    ForceBuySsm,
    /// <summary>
    /// Forced sell
    /// </summary>
    [Map("FORCE_SELL_SSM")]
    ForceSellSsm,
    /// <summary>
    /// Liquidation buy
    /// </summary>
    [Map("BURST_BUY_SSM")]
    BurstBuySsm,
    /// <summary>
    /// Liquidation sell
    /// </summary>
    [Map("BURST_SELL_SSM")]
    BurstSellSsm,
    /// <summary>
    /// Risk control liability liquidation, user credit
    /// </summary>
    [Map("RISK_LIQ_USER_IN")]
    RiskLiqUserIn,
    /// <summary>
    /// Interest deduction
    /// </summary>
    [Map("INTEREST_SETTLEMENT_OUT")]
    InterestSettlementOut,
    /// <summary>
    /// Cross-margin funding fee in
    /// </summary>
    [Map("CONTRACT_MAIN_SETTLE_FEE_USER_IN")]
    ContractMainSettleFeeUserIn,
    /// <summary>
    /// Cross-margin funding fee out
    /// </summary>
    [Map("CONTRACT_MAIN_SETTLE_FEE_USER_OUT")]
    ContractMainSettleFeeUserOut,
    /// <summary>
    /// Risk control liability liquidation, user debit
    /// </summary>
    [Map("RISK_LIQ_USER_OUT")]
    RiskLiqUserOut,
    /// <summary>
    /// Ins loan borrow
    /// </summary>
    [Map("BORROW")]
    Borrow,
    /// <summary>
    /// Reserve transfer in
    /// </summary>
    [Map("RESERVE_TRANSFER_IN")]
    ReserveTransferIn,
    /// <summary>
    /// Reserve transfer out
    /// </summary>
    [Map("RESERVE_TRANSFER_OUT")]
    ReserveTransferOut,
    /// <summary>
    /// Ins loan repayment
    /// </summary>
    [Map("REPAYMENT")]
    Repayment,
    /// <summary>
    /// Interest repayment
    /// </summary>
    [Map("INTEREST_REPAYMENT")]
    InterestRepayment,
    /// <summary>
    /// Liquidation fund out
    /// </summary>
    [Map("LIQ_FUND_OUT")]
    LiqFundOut,
    /// <summary>
    /// Liquidation convert user out
    /// </summary>
    [Map("LIQ_CONVERT_USER_OUT")]
    LiqConvertUserOut,
    /// <summary>
    /// Liquidation convert system in
    /// </summary>
    [Map("LIQ_CONVERT_SYS_IN")]
    LiqConvertSysIn,
    /// <summary>
    /// Liquidation convert system out
    /// </summary>
    [Map("LIQ_CONVERT_SYS_OUT")]
    LiqConvertSysOut,
    /// <summary>
    /// Liquidation convert user in
    /// </summary>
    [Map("LIQ_CONVERT_USER_IN")]
    LiqConvertUserIn,
    /// <summary>
    /// Liquidation transfer in
    /// </summary>
    [Map("LIQ_TRANSFER_IN")]
    LiqTransferIn,
    /// <summary>
    /// Liquidation transfer out
    /// </summary>
    [Map("LIQ_TRANSFER_OUT")]
    LiqTransferOut,
    /// <summary>
    /// Liquidation fund in
    /// </summary>
    [Map("LIQ_FUND_IN")]
    LiqFundIn,
    /// <summary>
    /// Liquidation fee
    /// </summary>
    [Map("LIQ_FEE")]
    LiqFee,
    /// <summary>
    /// Liquidation repayment
    /// </summary>
    [Map("LIQ_REPAYMENT")]
    LiqRepayment,
    /// <summary>
    /// Margin token delist exchange out, user debit
    /// </summary>
    [Map("DELIST_MARGIN_TOKEN_SOURCE_USER_OUT")]
    DelistMarginTokenSourceUserOut,
    /// <summary>
    /// Margin token delist exchange in, system credit
    /// </summary>
    [Map("DELIST_MARGIN_TOKEN_SOURCE_SYS_IN")]
    DelistMarginTokenSourceSysIn,
    /// <summary>
    /// Margin token delist exchange out, system debit
    /// </summary>
    [Map("DELIST_MARGIN_TOKEN_TARGET_SYS_OUT")]
    DelistMarginTokenTargetSysOut,
    /// <summary>
    /// Margin token delist exchange in, user credit
    /// </summary>
    [Map("DELIST_MARGIN_TOKEN_TARGET_USER_IN")]
    DelistMarginTokenTargetUserIn,
    /// <summary>
    /// Asset confiscation user debit
    /// </summary>
    [Map("CONFISCATE_TOKEN_USER_OUT")]
    ConfiscateTokenUserOut,
    /// <summary>
    /// Asset confiscation system credit
    /// </summary>
    [Map("CONFISCATE_TOKEN_SYS_IN")]
    ConfiscateTokenSysIn,
    /// <summary>
    /// Margin token delist small balance, user out
    /// </summary>
    [Map("DELIST_SMALL_BALANCE_USER_OUT")]
    DelistSmallBalanceUserOut,
    /// <summary>
    /// Margin token delist small balance, system in
    /// </summary>
    [Map("DELIST_SMALL_BALANCE_SYS_IN")]
    DelistSmallBalanceSysIn,
    /// <summary>
    /// Margin token delist small liability, system out
    /// </summary>
    [Map("DELIST_SMALL_LIABILITY_SYS_OUT")]
    DelistSmallLiabilitySysOut,
    /// <summary>
    /// Margin token delist small liability, user in
    /// </summary>
    [Map("DELIST_SMALL_LIABILITY_USER_IN")]
    DelistSmallLiabilityUserIn,
    /// <summary>
    /// Small asset conversion source token, user out
    /// </summary>
    [Map("SMALL_ASSET_SOURCE_TOKEN_USER_OUT")]
    SmallAssetSourceTokenUserOut,
    /// <summary>
    /// Small asset conversion source token, system in
    /// </summary>
    [Map("SMALL_ASSET_SOURCE_TOKEN_SYS_IN")]
    SmallAssetSourceTokenSysIn,
    /// <summary>
    /// Small asset conversion target token, system out
    /// </summary>
    [Map("SMALL_ASSET_TARGET_TOKEN_SYS_OUT")]
    SmallAssetTargetTokenSysOut,
    /// <summary>
    /// Small asset conversion target token, user in
    /// </summary>
    [Map("SMALL_ASSET_TARGET_TOKEN_USER_IN")]
    SmallAssetTargetTokenUserIn,
    /// <summary>
    /// Small asset conversion fee, system in
    /// </summary>
    [Map("SMALL_ASSET_FEE_SYS_IN")]
    SmallAssetFeeSysIn,
    /// <summary>
    /// Copy trading profit sharing user out
    /// </summary>
    [Map("TRACE_SHARE_BENEFIT_USER_OUT")]
    TraceShareBenefitUserOut,
    /// <summary>
    /// Copy trading profit sharing system in
    /// </summary>
    [Map("TRACE_SHARE_BENEFIT_SYSTEM_IN")]
    TraceShareBenefitSystemIn,
    /// <summary>
    /// Copy trading profit sharing system out
    /// </summary>
    [Map("TRACE_SHARE_BENEFIT_SYSTEM_OUT")]
    TraceShareBenefitSystemOut,
    /// <summary>
    /// Copy trading profit sharing user in
    /// </summary>
    [Map("TRACE_SHARE_BENEFIT_USER_IN")]
    TraceShareBenefitUserIn,
    /// <summary>
    /// Isolated open long
    /// </summary>
    [Map("MARGIN_OPEN_LONG")]
    MarginOpenLong,
    /// <summary>
    /// Isolated open short
    /// </summary>
    [Map("MARGIN_OPEN_SHORT")]
    MarginOpenShort,
    /// <summary>
    /// Isolated single-sided buy
    /// </summary>
    [Map("MARIN_BUY_DEAL")]
    MarinBuyDeal,
    /// <summary>
    /// Isolated single-sided sell
    /// </summary>
    [Map("MARIN_SELL_DEAL")]
    MarinSellDeal,
    /// <summary>
    /// Isolated position refund
    /// </summary>
    [Map("MARGIN_BACK")]
    MarginBack,
    /// <summary>
    /// Add isolated margin
    /// </summary>
    [Map("INCREASE_MARGIN")]
    IncreaseMargin,
    /// <summary>
    /// Reduce isolated margin
    /// </summary>
    [Map("REDUCE_MARGIN")]
    ReduceMargin,
    /// <summary>
    /// Isolated funding fee in
    /// </summary>
    [Map("MARGIN_SETTLE_FEE_USER_IN")]
    MarginSettleFeeUserIn,
    /// <summary>
    /// Isolated funding fee out
    /// </summary>
    [Map("MARGIN_SETTLE_FEE_USER_OUT")]
    MarginSettleFeeUserOut,
    /// <summary>
    /// Isolated leverage adjustment order unfreeze
    /// </summary>
    [Map("MARGIN_LEVER_ORDER_REFROZEN")]
    MarginLeverOrderRefrozen,
    /// <summary>
    /// Isolated leverage adjustment order freeze
    /// </summary>
    [Map("MARGIN_LEVER_ORDER_FROZEN")]
    MarginLeverOrderFrozen,
    /// <summary>
    /// Isolated leverage adjustment position margin add
    /// </summary>
    [Map("MARGIN_LEVER_POS_IN")]
    MarginLeverPosIn,
    /// <summary>
    /// Isolated single-sided long reduce-only
    /// </summary>
    [Map("MARGIN_OFFSET_IN_SSM_LONG")]
    MarginOffsetInSsmLong,
    /// <summary>
    /// Isolated single-sided short reduce-only
    /// </summary>
    [Map("MARGIN_OFFSET_IN_SSM_SHORT")]
    MarginOffsetInSsmShort,
    /// <summary>
    /// Isolated reduce long
    /// </summary>
    [Map("FIXED_OFFSET_IN_SSM_LONG")]
    FixedOffsetInSsmLong,
    /// <summary>
    /// Isolated reduce short
    /// </summary>
    [Map("FIXED_OFFSET_IN_SSM_SHORT")]
    FixedOffsetInSsmShort,
    /// <summary>
    /// Isolated close long
    /// </summary>
    [Map("FIXED_CLOSE_LONG")]
    FixedCloseLong,
    /// <summary>
    /// Isolated close short
    /// </summary>
    [Map("FIXED_CLOSE_SHORT")]
    FixedCloseShort,
    /// <summary>
    /// Isolated forced reduction of long
    /// </summary>
    [Map("FIXED_FORCE_CLOSE_LONG")]
    FixedForceCloseLong,
    /// <summary>
    /// Isolated forced reduction of short
    /// </summary>
    [Map("FIXED_FORCE_CLOSE_SHORT")]
    FixedForceCloseShort,
    /// <summary>
    /// Isolated liquidate long
    /// </summary>
    [Map("FIXED_BURST_CLOSE_LONG")]
    FixedBurstCloseLong,
    /// <summary>
    /// Isolated liquidate short
    /// </summary>
    [Map("FIXED_BURST_CLOSE_SHORT")]
    FixedBurstCloseShort,
    /// <summary>
    /// Isolated adl close long
    /// </summary>
    [Map("FIXED_ADL_CLOSE_LONG")]
    FixedAutoDeleverageCloseLong,
    /// <summary>
    /// Isolated adl close short
    /// </summary>
    [Map("FIXED_ADL_CLOSE_SHORT")]
    FixedAutoDeleverageCloseShort,
    /// <summary>
    /// Isolated risk control liability liquidation, user credit
    /// </summary>
    [Map("FIXED_RISK_LIQ_USER_IN")]
    FixedRiskLiqUserIn,
    /// <summary>
    /// Isolated risk control liability liquidation, user debit
    /// </summary>
    [Map("FIXED_RISK_LIQ_USER_OUT")]
    FixedRiskLiqUserOut,
    /// <summary>
    /// Isolated forced buy
    /// </summary>
    [Map("FIXED_FORCE_BUY_SSM")]
    FixedForceBuySsm,
    /// <summary>
    /// Isolated forced sell
    /// </summary>
    [Map("FIXED_FORCE_SELL_SSM")]
    FixedForceSellSsm,
    /// <summary>
    /// Isolated liquidation buy
    /// </summary>
    [Map("FIXED_BURST_BUY_SSM")]
    FixedBurstBuySsm,
    /// <summary>
    /// Isolated liquidation sell
    /// </summary>
    [Map("FIXED_BURST_SELL_SSM")]
    FixedBurstSellSsm,
    /// <summary>
    /// On-chain transfer user in
    /// </summary>
    [Map("ON_CHAIN_TRANSFER_REFUND")]
    OnChainTransferRefund,
    /// <summary>
    /// On-chain transfer user out
    /// </summary>
    [Map("ON_CHAIN_TRANSFER_OUT")]
    OnChainTransferOut,
    /// <summary>
    /// Transfer in from mt5
    /// </summary>
    [Map("MT5_TRANSFER_IN")]
    MT5TRANSFERIN,
    /// <summary>
    /// MT5 transfer out refund
    /// </summary>
    [Map("MT5_REFUND_IN")]
    MT5REFUNDIN,
    /// <summary>
    /// Transfer out to mt5
    /// </summary>
    [Map("MT5_TRANSFER_OUT")]
    MT5TRANSFEROUT,
    /// <summary>
    /// Copy trading freeze user out
    /// </summary>
    [Map("TRACE_LOCK_USER_OUT")]
    TraceLockUserOut,
    /// <summary>
    /// Copy trading freeze user in
    /// </summary>
    [Map("TRACE_LOCK_USER_IN")]
    TraceLockUserIn,
    /// <summary>
    /// Copy trading from uta to funding account
    /// </summary>
    [Map("TRACE_TRANSFER_USER_OUT")]
    TraceTransferUserOut,
    /// <summary>
    /// Copy trading from funding account to uta sub-account
    /// </summary>
    [Map("TRACE_TRANSFER_USER_IN")]
    TraceTransferUserIn,
    /// <summary>
    /// Copy trading funding account refund to uta
    /// </summary>
    [Map("TRACE_TRANSFER_REFUND_IN")]
    TraceTransferRefundIn,
    /// <summary>
    /// Earn transfer out
    /// </summary>
    [Map("FINANCIAL_TRANSFER_OUT")]
    FinancialTransferOut,
    /// <summary>
    /// Earn transfer in
    /// </summary>
    [Map("FINANCIAL_TRANSFER_IN")]
    FinancialTransferIn,
    /// <summary>
    /// Convert transfer in
    /// </summary>
    [Map("CONVERT_TRANSFER_IN")]
    ConvertTransferIn,
    /// <summary>
    /// Convert transfer out
    /// </summary>
    [Map("CONVERT_TRANSFER_OUT")]
    ConvertTransferOut,
    /// <summary>
    /// BG pay transfer out
    /// </summary>
    [Map("BGPAY_TRANSFER_OUT")]
    BgpayTransferOut,
    /// <summary>
    /// BG pay refund in
    /// </summary>
    [Map("BGPAY_REFUND_IN")]
    BgpayRefundIn,
    /// <summary>
    /// RWA cash dividend isolated margin funding fee user credit
    /// </summary>
    [Map("RWA_FIXED_SETTLE_FEE_USER_IN")]
    RwaFixedSettleFeeUserIn,
    /// <summary>
    /// RWA cash dividend isolated margin funding fee user debit
    /// </summary>
    [Map("RWA_FIXED_SETTLE_FEE_USER_OUT")]
    RwaFixedSettleFeeUserOut,
    /// <summary>
    /// RWA cash dividend cross margin funding fee aggregation account credit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_SYSTEM_IN")]
    RwaContractMainSettleFeeSystemIn,
    /// <summary>
    /// RWA cash dividend cross margin funding fee aggregation account debit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_SYSTEM_OUT")]
    RwaContractMainSettleFeeSystemOut,
    /// <summary>
    /// RWA cash dividend cross margin funding fee reserve account credit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_SYSTEM_KEEP_IN")]
    RwaContractMainSettleFeeSystemKeepIn,
    /// <summary>
    /// RWA cash dividend cross margin funding fee reserve account debit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_SYSTEM_KEEP_OUT")]
    RwaContractMainSettleFeeSystemKeepOut,
    /// <summary>
    /// RWA cash dividend cross margin funding fee user credit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_USER_IN")]
    RwaContractMainSettleFeeUserIn,
    /// <summary>
    /// RWA cash dividend cross margin funding fee user debit
    /// </summary>
    [Map("RWA_CONTRACT_MAIN_SETTLE_FEE_USER_OUT")]
    RwaContractMainSettleFeeUserOut,
    /// <summary>
    /// RWA contract rebase open long
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_OPEN_LONG")]
    RwaContractRebaseUserOpenLong,
    /// <summary>
    /// RWA contract rebase open short
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_OPEN_SHORT")]
    RwaContractRebaseUserOpenShort,
    /// <summary>
    /// RWA contract rebase close long
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_CLOSE_LONG")]
    RwaContractRebaseUserCloseLong,
    /// <summary>
    /// RWA contract rebase close short
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_CLOSE_SHORT")]
    RwaContractRebaseUserCloseShort,
    /// <summary>
    /// RWA contract rebase buy in single side mode
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_BUY_IN_SSM")]
    RwaContractRebaseUserBuyInSsm,
    /// <summary>
    /// RWA contract rebase sell in single side mode
    /// </summary>
    [Map("RWA_CONTRACT_REBASE_USER_SELL_IN_SSM")]
    RwaContractRebaseUserSellInSsm,
}
