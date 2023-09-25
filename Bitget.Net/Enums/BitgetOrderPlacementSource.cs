using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Placement source
    /// </summary>
    public enum BitgetOrderPlacementSource
    {
        /// <summary>
        /// Web
        /// </summary>
        [Map("WEB")]
        Web,
        /// <summary>
        /// App
        /// </summary>
        [Map("APP")]
        App,
        /// <summary>
        /// Api
        /// </summary>
        [Map("API")]
        Api,
        /// <summary>
        /// Sys
        /// </summary>
        [Map("SYS")]
        Sys,
        /// <summary>
        /// Android
        /// </summary>
        [Map("ANDROID")]
        Android,
        /// <summary>
        /// Ios
        /// </summary>
        [Map("IOS")]
        Ios
    }
}
