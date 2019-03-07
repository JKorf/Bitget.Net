﻿using System.Collections.Generic;
using Bitfinex.Net.Objects;
using CryptoExchange.Net.Converters;

namespace Bitfinex.Net.Converters
{
    public class StatSideConverter: BaseConverter<StatSide>
    {
        public StatSideConverter(): this(true) { }
        public StatSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<StatSide, string>> Mapping => new List<KeyValuePair<StatSide, string>>
        {
            new KeyValuePair<StatSide, string>(StatSide.Long, "long"),
            new KeyValuePair<StatSide, string>(StatSide.Short, "short")
        };
    }
}
