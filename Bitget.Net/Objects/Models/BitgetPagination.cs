using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Paginated result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BitgetPagination<T>
    {
        /// <summary>
        /// Has another page
        /// </summary>
        [JsonProperty("nextFlag")]
        public bool HasNext { get; set; }
        /// <summary>
        /// Last id of the results, can be used for requesting the next page
        /// </summary>
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// Paged data
        /// </summary>
        [JsonProperty("orderList")]
        public IEnumerable<T> Data { get; set; } = Array.Empty<T>();

        [JsonProperty("list")]
        internal IEnumerable<T> IntData1 { get => Data; set => Data = value; }
        [JsonProperty("result")]
        internal IEnumerable<T> IntData2 { get => Data; set => Data = value; }
    }
}
