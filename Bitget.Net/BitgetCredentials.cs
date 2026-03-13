using CryptoExchange.Net.Authentication;

namespace Bitget.Net
{
    /// <summary>
    /// Bitget credentials
    /// </summary>
    public class BitgetCredentials : ApiCredentials
    {
        /// <summary>
        /// Credential type provided
        /// </summary>
        public ApiCredentialsType CredentialType => CredentialPairs.First().CredentialType;

        internal string? Passphrase =>
            CredentialType == ApiCredentialsType.Hmac ? GetCredential<HMACCredential>()?.Pass
            : CredentialType == ApiCredentialsType.Rsa ? GetCredential<RSACredential>()?.Passphrase
            : null;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="apiKey">The API key</param>
        /// <param name="secret">The API secret</param>
        /// <param name="passphrase">The API passphrase</param>
        public BitgetCredentials(string apiKey, string secret, string passphrase) : this(new HMACCredential(apiKey, secret, passphrase)) { }

        /// <summary>
        /// Create Bitget credentials using HMAC credentials
        /// </summary>
        /// <param name="credential">The HMAC credentials</param>
        public BitgetCredentials(HMACCredential credential) : base(credential) { }

        /// <summary>
        /// Create Bitget credentials using RSA credentials
        /// </summary>
        /// <param name="rsaCredential">RSA credentials</param>
        public BitgetCredentials(RSACredential rsaCredential)
            : base(rsaCredential)
        {
        }

        /// <inheritdoc />
        public override ApiCredentials Copy() =>
            CredentialType switch
            {
                ApiCredentialsType.Hmac => new BitgetCredentials(GetCredential<HMACCredential>()!),
                ApiCredentialsType.Rsa => new BitgetCredentials(GetCredential<RSACredential>()!)
            };
    }
}
