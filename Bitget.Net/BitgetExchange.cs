namespace Bitget.Net
{
    /// <summary>
    /// Bitget exchange information and configuration
    /// </summary>
    public static class BitgetExchange
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bitget";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.bitget.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://bitgetlimited.github.io/apidoc/en/mix/#welcome",
            "https://www.bitget.com/api-doc"
            };
    }
}
