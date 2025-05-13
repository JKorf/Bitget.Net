using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget options
    /// </summary>
    public class BitgetOptions : LibraryOptions<BitgetRestOptions, BitgetSocketOptions, ApiCredentials, BitgetEnvironment>
    {
    }
}
