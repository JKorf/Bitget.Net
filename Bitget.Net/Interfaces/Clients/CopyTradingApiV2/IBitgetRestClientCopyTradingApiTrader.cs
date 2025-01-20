using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.CopyTradingApiV2
{
    /// <summary>
    /// Bitget copy trading endpoints.
    /// </summary>
    public interface IBitgetRestClientCopyTradingApiTrader
    {
        /// <summary>
        /// Get Copy Trade Symbol Settings
        /// <para><a href="https://www.bitget.com/api-doc/copytrading/future-copytrade/trader/Trader-Get-Config-Query-Symbols" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetCopyTradingSymbolSettings[]>> GetCopyTradeSymbolSettings(BitgetProductTypeV2 productType, CancellationToken ct = default);
    }
}
