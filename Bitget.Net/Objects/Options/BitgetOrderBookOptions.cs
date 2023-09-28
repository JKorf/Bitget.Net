using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Order book options
    /// </summary>
    public class BitgetOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// Default options for new order books
        /// </summary>
        public static BitgetOrderBookOptions Default { get; set; } = new BitgetOrderBookOptions();

        /// <summary>
        /// The limit of entries in the order book, either 5, 15 or null
        /// </summary>
        public int? Limit { get; set; }

        internal BitgetOrderBookOptions Copy()
        {
            var options = Copy<BitgetOrderBookOptions>();
            options.Limit = Limit;
            return options;
        }
    }
}
