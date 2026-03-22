using CryptoExchange.Net.Authentication;

namespace Bitget.Net
{
    /// <summary>
    /// Bitget credentials
    /// </summary>
    public class BitgetCredentials : ApiCredentials
    {
        internal CredentialSet Credential { get; set; }
        internal string Passphrase =>
            (HMAC?.Pass 
            ?? RSAXml?.Pass
#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
            ?? RSAPem?.Pass
#endif
            )!;

        /// <summary>
        /// HMAC credentials
        /// </summary>
        public HMACPassCredential? HMAC
        {
            get => Credential as HMACPassCredential;
            set { if (value != null) Credential = value; }
        }

        /// <summary>
        /// RSA credentials in XML format
        /// </summary>
        public RSAXmlPassCredential? RSAXml
        {
            get => Credential as RSAXmlPassCredential;
            set { if (value != null) Credential = value; }
        }

#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
        /// <summary>
        /// RSA credentials in PEM/Base64 format
        /// </summary>
        public RSAPemPassCredential? RSAPem
        {
            get => Credential as RSAPemPassCredential;
            set { if (value != null) Credential = value; }
        }
#endif

        /// <summary>
        /// Create new credentials
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BitgetCredentials() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        /// <summary>
        /// Create new credentials providing HMAC credentials
        /// </summary>
        /// <param name="key">API key</param>
        /// <param name="secret">API secret</param>
        /// <param name="pass">Passphrase</param>
        public BitgetCredentials(string key, string secret, string pass)
        {
            Credential = new HMACPassCredential(key, secret, pass);
        }

        /// <summary>
        /// Create new credentials providing HMAC credentials
        /// </summary>
        /// <param name="credential">HMAC Credentials</param>
        public BitgetCredentials(HMACPassCredential credential)
        {
            Credential = credential;
        }

        /// <summary>
        /// Create new credentials providing RSA credentials in XML format
        /// </summary>
        /// <param name="credential">RSA Credentials in XML format</param>
        public BitgetCredentials(RSAXmlPassCredential credential)
        {
            Credential = credential;
        }

#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
        /// <summary>
        /// Create new credentials providing RSA credentials in PEM/Base64 format
        /// </summary>
        /// <param name="credential">RSA Credentials in PEM/Base64 format</param>
        public BitgetCredentials(RSAPemPassCredential credential)
        {
            Credential = credential;
        }
#endif

        /// <summary>
        /// Specify the HMAC credentials
        /// </summary>
        /// <param name="key">API key</param>
        /// <param name="secret">API secret</param>
        /// <param name="pass">Passphrase</param>
        public BitgetCredentials WithHMAC(string key, string secret, string pass)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new HMACPassCredential(key, secret, pass);
            return this;
        }

        /// <summary>
        /// Specify the RSA credentials in XML format
        /// </summary>
        /// <param name="key">API key</param>
        /// <param name="privateKey">Private key</param>
        /// <param name="pass">Passphrase</param>
        public BitgetCredentials WithRSAXml(string key, string privateKey, string pass)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new RSAXmlPassCredential(key, privateKey, pass);
            return this;
        }

#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
        /// <summary>
        /// Specify the RSA credentials in PEM/Base64 format
        /// </summary>
        /// <param name="key">API key</param>
        /// <param name="privateKey">Private key</param>
        /// <param name="pass">Passphrase</param>
        public BitgetCredentials WithRSAPem(string key, string privateKey, string pass)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new RSAPemPassCredential(key, privateKey, pass);
            return this;
        }
#endif

        /// <inheritdoc />
        public override ApiCredentials Copy() => new BitgetCredentials { Credential = Credential };

        /// <inheritdoc />
        public override void Validate()
        {
            if (Credential == null)
                throw new ArgumentException($"No credentials provided on {GetType().Name}");

            Credential.Validate();
        }
    }
}
