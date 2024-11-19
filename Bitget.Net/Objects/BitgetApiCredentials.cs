using CryptoExchange.Net.Authentication;
using System.Security;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters.MessageParsing;

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
        public string PassPhrase { get; set; }

        /// <summary>
        /// Creates new api credentials. Keep this information safe.
        /// </summary>
        /// <param name="key">The API key</param>
        /// <param name="secret">The API secret</param>
        /// <param name="passPhrase">The API passPhrase</param>
        /// <param name="credentialType">The type of credentials</param>
        public BitgetApiCredentials(string key, string secret, string passPhrase, ApiCredentialsType credentialType = ApiCredentialsType.Hmac): base(key, secret, credentialType)
        {
            PassPhrase = passPhrase;
        }

        /// <summary>
        /// Create Api credentials providing a stream containing json data. The json data should include three values: apiKey, apiSecret and apiPassPhrase
        /// </summary>
        /// <param name="inputStream">The stream containing the json data</param>
        /// <param name="identifierKey">A key to identify the credentials for the API. For example, when set to `binanceKey` the json data should contain a value for the property `binanceKey`. Defaults to 'apiKey'.</param>
        /// <param name="identifierSecret">A key to identify the credentials for the API. For example, when set to `binanceSecret` the json data should contain a value for the property `binanceSecret`. Defaults to 'apiSecret'.</param>
        /// <param name="identifierPassPhrase">A key to identify the credentials for the API. For example, when set to `BitgetPass` the json data should contain a value for the property `BitgetPass`. Defaults to 'apiPassPhrase'.</param>
        public static BitgetApiCredentials FromStream(Stream inputStream, string? identifierKey = null, string? identifierSecret = null, string? identifierPassPhrase = null)
        {
            var accessor = new JsonNetStreamMessageAccessor();
            if (!accessor.Read(inputStream, false).Result)
                throw new ArgumentException("Input stream not valid json data");

            var key = accessor.GetValue<string>(MessagePath.Get().Property(identifierKey ?? "apiKey"));
            var secret = accessor.GetValue<string>(MessagePath.Get().Property(identifierSecret ?? "apiSecret"));
            var pass = accessor.GetValue<string>(MessagePath.Get().Property(identifierPassPhrase ?? "apiPassPhrase"));
            if (key == null || secret == null || pass == null)
                throw new ArgumentException("apiKey or apiSecret value not found in Json credential file");

            return new BitgetApiCredentials(key, secret, pass);
        }

        /// <inheritdoc />
        public override ApiCredentials Copy()
        {
            return new BitgetApiCredentials(Key, Secret, PassPhrase, CredentialType);
        }
    }
}
