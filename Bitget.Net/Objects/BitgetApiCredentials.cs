using CryptoExchange.Net.Authentication;
using System.Security;
using System.Text;
using CryptoExchange.Net;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Objects
{
    /// <summary>
    /// Credentials for the Bitget API
    /// </summary>
    public class BitgetApiCredentials : ApiCredentials
    {
        /// <summary>
        /// The pass phrase
        /// </summary>
        public SecureString PassPhrase { get; }

        /// <summary>
        /// Creates new api credentials. Keep this information safe.
        /// </summary>
        /// <param name="apiKey">The API key</param>
        /// <param name="apiSecret">The API secret</param>
        /// <param name="apiPassPhrase">The API passPhrase</param>
        public BitgetApiCredentials(string apiKey, string apiSecret, string apiPassPhrase): base(apiKey, apiSecret)
        {
            PassPhrase = apiPassPhrase.ToSecureString();
        }

        /// <summary>
        /// Create Api credentials providing a stream containing json data. The json data should include three values: apiKey, apiSecret and apiPassPhrase
        /// </summary>
        /// <param name="inputStream">The stream containing the json data</param>
        /// <param name="identifierKey">A key to identify the credentials for the API. For example, when set to `binanceKey` the json data should contain a value for the property `binanceKey`. Defaults to 'apiKey'.</param>
        /// <param name="identifierSecret">A key to identify the credentials for the API. For example, when set to `binanceSecret` the json data should contain a value for the property `binanceSecret`. Defaults to 'apiSecret'.</param>
        /// <param name="identifierPassPhrase">A key to identify the credentials for the API. For example, when set to `BitgetPass` the json data should contain a value for the property `BitgetPass`. Defaults to 'apiPassPhrase'.</param>
        public BitgetApiCredentials(Stream inputStream, string? identifierKey = null, string? identifierSecret = null, string? identifierPassPhrase = null) : base(inputStream, identifierKey, identifierSecret)
        {
            string? pass;
            using (var reader = new StreamReader(inputStream, Encoding.ASCII, false, 512, true))
            {
                var stringData = reader.ReadToEnd();
                var jsonData = JToken.Parse(stringData);
                pass = TryGetValue(jsonData, identifierKey ?? "apiPassPhrase");

                if (pass == null)
                    throw new ArgumentException($"PassPhrase value not found in Json credential file, key: {identifierPassPhrase ?? "apiPassPhrase"}");
            }

            inputStream.Seek(0, SeekOrigin.Begin);
            PassPhrase = pass.ToSecureString();
        }

        /// <inheritdoc />
        public override ApiCredentials Copy()
        {
            return new BitgetApiCredentials(Key!.GetString(), Secret!.GetString(), PassPhrase!.GetString());
        }
    }
}
