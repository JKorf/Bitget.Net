using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget Elite Trading endpoints.
    /// </summary>
    public interface IBitgetRestClientUnifiedApiCopyFutures
    {
        /// <summary>
        /// Get Trading Pairs
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/copy/futures-public/Get-Trading-Pairs" /><br />
        /// <a href="https://www.bitget.com/zh-CN/api-doc/uta/copy/futures-public/Get-Trading-Pairs" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/copy/futures/trading-pairs<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetCopyTradingSymbol[]>> GetTradingPairsAsync(CancellationToken ct = default);
    }
}
