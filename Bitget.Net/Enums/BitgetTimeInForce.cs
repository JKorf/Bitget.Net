using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    public enum BitgetTimeInForce
    {
        /// <summary>
        /// Good till canceled
        /// </summary>
        [Map("normal")]
        GoodTillCanceled,
        /// <summary>
        /// Post only
        /// </summary>
        [Map("post_only")]
        PostOnly,
        /// <summary>
        /// Fill or kill
        /// </summary>
        [Map("fok")]
        FillOrKill,
        /// <summary>
        /// Immediate or cancel
        /// </summary>
        [Map("ioc")]
        ImmediatOrCancel
    }
}
