using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Symbol status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<FuturesSymbolStatus>))]
    public enum FuturesSymbolStatus
    {
        /// <summary>
        /// ["<c>normal</c>"] Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// ["<c>maintain</c>"] In maintenance
        /// </summary>
        [Map("maintain")]
        Maintenance,
        /// <summary>
        /// ["<c>limit_open</c>"] Order placement restricted
        /// </summary>
        [Map("limit_open")]
        Limited,
        /// <summary>
        /// ["<c>restrictedAPI</c>"] API order placement restricted
        /// </summary>
        [Map("restrictedAPI")]
        RestrictedApi
    }
}
