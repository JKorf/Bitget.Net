using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Announcement type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AnnouncementType>))]
    public enum AnnouncementType
    {
        /// <summary>
        /// Latest news
        /// </summary>
        [Map("latest_news")]
        LatestNews,
        /// <summary>
        /// Coin listing
        /// </summary>
        [Map("coin_listings")]
        CoinListing,
        /// <summary>
        /// Product updates
        /// </summary>
        [Map("product_updates")]
        ProductUpdates,
        /// <summary>
        /// Security update
        /// </summary>
        [Map("security")]
        Security,
        /// <summary>
        /// Api trading update
        /// </summary>
        [Map("api_trading")]
        ApiTrading,
        /// <summary>
        /// Maintenance update
        /// </summary>
        [Map("maintenance_system_updates")]
        MaintenanceSystemUpdates,
        /// <summary>
        /// Delisting update
        /// </summary>
        [Map("symbol_delisting")]
        SymbolDelisting
    }
}
