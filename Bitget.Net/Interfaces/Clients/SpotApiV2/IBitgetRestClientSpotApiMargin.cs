using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget margin endpoints
    /// </summary>
    public interface IBitgetRestClientSpotApiMargin
    {
        /// <summary>
        /// Get margin symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/common/support-currencies" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/currencies
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMarginSymbol[]>> GetMarginSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get interest rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/common/interest-rate-record" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/interest-rate-record
        /// </para>
        /// </summary>
        /// <param name="asset">Asset name</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetInterestRate>> GetInterestRatesAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin borrow history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Loan-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/borrow-history
        /// </para>
        /// </summary>
        /// <param name="loanId">Filter by loanId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossBorrowHistory>>> GetCrossBorrowHistoryAsync(string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin repay history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Repay-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/repay-history
        /// </para>
        /// </summary>
        /// <param name="repayId">Filter by repayId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossRepayHistory>>> GetCrossRepayHistoryAsync(string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin interest history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Interest-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/interest-history
        /// </para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossInterest>>> GetCrossInterestHistoryAsync(string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin liquidation history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Liquidation-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/liquidation-history
        /// </para>
        /// </summary>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidation>>> GetCrossLiquidationHistoryAsync(
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin financial history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Finance-Flow-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/financial-records
        /// </para>
        /// </summary>
        /// <param name="marginType">Filter by margin type</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossFinancial>>> GetCrossFinancialHistoryAsync(
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/account/assets
        /// </para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossBalance[]>> GetCrossBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Cross margin borrow
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Borrow" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/account/borrow
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to borrow</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossBorrowResult>> CrossBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Cross margin repay
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Repay" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/account/repay
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to repay</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossRepayResult>> CrossRepayAsync(string asset, decimal quantity, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin risk rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Risk-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/account/risk-rate
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossRiskRate>> GetCrossRiskRateAsync(CancellationToken ct = default);

        /// <summary>
        /// Get cross margin max borrowable amount
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Max-Borrowable-Amount" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/account/max-borrowable-amount
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossMaxBorrowable>> GetCrossMaxBorrowableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin max transferable amount
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Max-Transfer-Out-Amount" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/account/max-transfer-out-amount
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossMaxTransferable>> GetCrossMaxTransferableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin interest rates and borrow limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Margin-Interest-Rate-And-Borrowable" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/interest-rate-and-limit
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossInterestLimit[]>> GetCrossInterestAndLimitAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin tier configuration
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Tier-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/tier-data
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossTierConfig[]>> GetCrossTierConfigAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Cross margin flash repay
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Flash-Repay" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/account/flash-repay
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`. If not provided cross margin account will be fully repaid.</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossFlashRepayResult>> CrossFlashRepayAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get flash repayment statuses
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/account/Query-Cross-Flash-Repay-Status" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/account/query-flash-repay-status
        /// </para>
        /// </summary>
        /// <param name="ids">Ids to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossFlashRepayStatus[]>> GetCrossFlashRepayStatusAsync(string ids, CancellationToken ct = default);

        /// <summary>
        /// Place a new cross margin order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Cross-Place-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/place-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="loanType">Loan type</param>
        /// <param name="orderSide">Order side</param>
        /// <param name="orderType">Order type</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Limit price</param>
        /// <param name="quantity">Quantity, not valid for market buy orders (use quoteQuantity)</param>
        /// <param name="quoteQuantity">Quantity in quote asset, for market buy orders</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="selfTradePreventionMode">Self trade prevention mode</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderId>> PlaceCrossOrderAsync(
            string symbol,
            LoanType loanType,
            OrderSide orderSide,
            OrderType orderType,
            TimeInForce timeInForce,
            decimal? price = null,
            decimal? quantity = null,
            string? quoteQuantity = null,
            string? clientOrderId = null,
            SelfTradePreventionMode? selfTradePreventionMode = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple new orders in a single call
        /// </summary>
        /// <param name="symbol">Symbol name</param>
        /// <param name="requests">Order requests</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderResult[]>> PlaceMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel cross margin order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Cross-Cancel-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/cancel-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderId>> CancelCrossOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders in a single call
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Cross-Batch-Cancel-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/crossed/batch-cancel-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orders">Orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin open orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Get-Cross-Open-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/open-orders
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed cross margin orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Get-Cross-Order-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/history-orders
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="enterPointSource">Filter by entry point</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin user trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Get-Cross-Order-Fills" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/fills
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetCrossUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin liquidation history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Get-Cross-Liquidation-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/crossed/liquidation-order
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="type">Filter by type</param>
        /// <param name="fromAsset">From asset (only for Swap type)</param>
        /// <param name="toAsset">To asset (only for Swap type)</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetCrossLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);


        /// <summary>
        /// Get Isolated margin borrow history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/record/Get-Isolated-Loan-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/borrow-history
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="loanId">Filter by loanId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>> GetIsolatedBorrowHistoryAsync(
            string symbol,
            string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin repay history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/record/Get-Isolated-Repay-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/repay-history
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="repayId">Filter by repayId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>> GetIsolatedRepayHistoryAsync(
            string symbol,
            string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin interest history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/record/Get-Isolated-Interest-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/interest-history
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedInterest>>> GetIsolatedInterestHistoryAsync(
            string symbol,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin liquidation history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/record/Get-Isolated-Liquidation-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/liquidation-history
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedLiquidation>>> GetIsolatedLiquidationHistoryAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin financial history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/record/Get-Isolated-Finance-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/financial-records
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="marginType">Filter by margin type</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedFinancial>>> GetIsolatedFinancialHistoryAsync(
            string symbol,
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Get-Isolated-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/account/assets
        /// </para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedBalance[]>> GetIsolatedBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin borrow
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Borrow" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/account/borrow
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to borrow</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedBorrowResult>> IsolatedBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin repay
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Repay" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/account/repay
        /// </para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to repay</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedRepayResult>> IsolatedRepayAsync(string asset, decimal quantity, CancellationToken ct = default);

        /// <summary>
        /// Get Isolated margin risk rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Risk-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/account/risk-rate
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedRiskRate[]>> GetIsolatedRiskRateAsync(CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin interest rates and limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Margin-Interest-Rate-And-Max-Borrowable-Amount" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/interest-rate-and-limit
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedInterestLimit[]>> GetIsolatedInterestAndLimitAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin tier configuration
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Tier-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/tier-data
        /// </para>
        /// </summary>
        /// <param name="symbol">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedTierConfig[]>> GetIsolatedTierConfigAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin max borrowable
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Max-Borrowable-Amount" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/account/max-borrowable-amount
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedMaxBorrowable>> GetIsolatedMaxBorrowableAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin max transferable
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Get-Isolated-Max-Transfer-Out-Amount" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/account/max-transfer-out-amount
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedMaxTransferable>> GetIsolatedMaxTransferableAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin flash repay
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Isolated-Flash-Repay" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/account/flash-repay
        /// </para>
        /// </summary>
        /// <param name="symbols">The symbols to repay. If not provided all isolated symbols will be repayed.</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetIsolatedFlashRepayResult[]>> IsolatedFlashRepayAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default);

        /// <summary>
        /// Get flash repayment statuses
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/account/Query-Isolated-Flash-Repay-Status" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/account/query-flash-repay-status
        /// </para>
        /// </summary>
        /// <param name="ids">Ids to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossFlashRepayStatus[]>> GetIsolatedFlashRepayStatusAsync(string ids, CancellationToken ct = default);

        /// <summary>
        /// Place a new isolated margin order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/cross/trade/Cross-Place-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/place-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="loanType">Loan type</param>
        /// <param name="orderSide">Order side</param>
        /// <param name="orderType">Order type</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Limit price</param>
        /// <param name="quantity">Quantity, not valid for market buy orders (use quoteQuantity)</param>
        /// <param name="quoteQuantity">Quantity in quote asset, for market buy orders</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="selfTradePreventionMode">Self trade prevention mode</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderId>> PlaceIsolatedOrderAsync(
            string symbol,
            LoanType loanType,
            OrderSide orderSide,
            OrderType orderType,
            TimeInForce timeInForce,
            decimal? price = null,
            decimal? quantity = null,
            string? quoteQuantity = null,
            string? clientOrderId = null,
            SelfTradePreventionMode? selfTradePreventionMode = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple new isolated margin orders in a single call
        /// </summary>
        /// <param name="symbol">Symbol name</param>
        /// <param name="requests">Order requests</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderResult[]>> PlaceMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel isolated margin order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Isolated-Cancel-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/cancel-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderId>> CancelIsolatedOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple isolated orders in a single call
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Isolated-Batch-Cancel-Orders" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/margin/isolated/batch-cancel-order
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orders">Orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin open orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Isolated-Open-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/open-orders
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed isolated margin orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Get-Isolated-Order-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/history-orders
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="enterPointSource">Filter by entry point</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin user trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Get-Isolated-Transaction-Details" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/fills
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetIsolatedUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin liquidation history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/margin/isolated/trade/Get-Isolated-Liquidation-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/margin/isolated/liquidation-order
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="type">Filter by type</param>
        /// <param name="fromAsset">From asset (only for Swap type)</param>
        /// <param name="toAsset">To asset (only for Swap type)</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetIsolatedLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

    }
}
