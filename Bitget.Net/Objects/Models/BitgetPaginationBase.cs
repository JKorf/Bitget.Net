namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Paginated result
    /// </summary>
    public class BitgetPaginationBase
    {
        /// <summary>
        /// Last id of the results, can be used for requesting the next page
        /// </summary>
        public string EndId { get; set; } = string.Empty;
    }
}
