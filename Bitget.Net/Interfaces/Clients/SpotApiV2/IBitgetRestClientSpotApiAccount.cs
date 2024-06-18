using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientSpotApiAccount
    {

        /// <summary>
        /// Get trading fee for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/common/public/Get-Trade-Rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="businessType">Business type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserFee>> GetTradeFeeAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default);

        /// <summary>
        /// Get asset valuation per account type
        /// <para><a href="https://www.bitget.com/api-doc/common/account/All-Account-Balance" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetAssetValue>>> GetAssetsValuationAsync(CancellationToken ct = default);
    }
}
