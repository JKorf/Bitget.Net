using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    public interface IBitgetRestClientSpotApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get server notifications of the last month
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#notice" /></para>
        /// </summary>
        /// <param name="languageType">The language type</param>
        /// <param name="noticeType">Filter by notice type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetNotification>>> GetNotificationsAsync(string languageType, string? noticeType = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of supported assets on the platform
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-list" /></para>
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(CancellationToken ct = default);
    }
}
