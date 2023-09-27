using Bitget.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;

namespace Bitget.Net
{
    internal class BitgetAuthenticationProvider : AuthenticationProvider<BitgetApiCredentials>
    {
        public string ApiKey => _credentials.Key!.GetString();
        public string Passphrase => _credentials.PassPhrase!.GetString();

        public BitgetAuthenticationProvider(BitgetApiCredentials credentials) : base(credentials)
        {
            if (credentials.CredentialType != ApiCredentialsType.Hmac)
                throw new Exception("Only Hmac authentication is supported");
        }

        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters, out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>();

            if (!auth)
                return;

            if (_credentials.CredentialType == ApiCredentialsType.Hmac)
            {
                var body = parameterPosition == HttpMethodParameterPosition.InBody ? JsonConvert.SerializeObject(bodyParameters) : "";

                var timestamp = GetMillisecondTimestamp(apiClient);
                var signString = timestamp + method.ToString().ToUpperInvariant() + uri.PathAndQuery + body;
                var sign = SignHMACSHA256(signString, SignOutputType.Base64);
                headers["ACCESS-KEY"] = _credentials.Key!.GetString();
                headers["ACCESS-SIGN"] = sign;
                headers["ACCESS-TIMESTAMP"] = timestamp;
                headers["ACCESS-PASSPHRASE"] = _credentials.PassPhrase.GetString();
            }
            else
            {
                 
            }
        }

        public string GetWebsocketSignature(long timestamp)
        {
            return SignHMACSHA256(timestamp + "GET" + "/user/verify", SignOutputType.Base64);
        }
    }
}
