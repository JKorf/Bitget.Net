using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Symbol status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SymbolStatus>))]
    public enum SymbolStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// In maintenance
        /// </summary>
        [Map("maintain")]
        Maintainance,
        /// <summary>
        /// Order placement restricted
        /// </summary>
        [Map("limit_open")]
        Limited,
        /// <summary>
        /// API order placement restricted
        /// </summary>
        [Map("restrictedAPI")]
        RestrictedApi
    }
}
