using Bitget.Net.Clients;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.OrderBook;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.SymbolOrderBooks
{
    /// <summary>
    /// Live order book implementation
    /// </summary>
    public class BitgetUnifiedSymbolOrderBook : SymbolOrderBook
    {
        private readonly IBitgetSocketClient _socketClient;
        private bool _initial = true;
        private readonly bool _clientOwner;
        private readonly ProductCategory _category;

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="category">The symbol category</param>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetUnifiedSymbolOrderBook(ProductCategory category, string symbol, Action<BitgetOrderBookOptions>? optionsDelegate = null)
            : this(category, symbol, optionsDelegate, null, null)
        {
            _clientOwner = true;
        }

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="category">The symbol category</param>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        /// <param name="logger">Logger</param>
        /// <param name="socketClient">Socket client instance</param>
        public BitgetUnifiedSymbolOrderBook(ProductCategory category,
            string symbol,
            Action<BitgetOrderBookOptions>? optionsDelegate,
            ILoggerFactory? logger,
            IBitgetSocketClient? socketClient) : base(logger, "Bitget", "Unified", symbol)
        {
            var options = BitgetOrderBookOptions.Default.Copy();
            if (optionsDelegate != null)
                optionsDelegate(options);
            Initialize(options);

            _category = category;
            _socketClient = socketClient ?? new BitgetSocketClient();
            _clientOwner = socketClient == null;
            _skipSequenceCheckFirstUpdateAfterSnapshotSet = true;

            Levels = options?.Limit;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync(CancellationToken ct)
        {
            CallResult<UpdateSubscription> result;
            if (Levels != null)
                result = await _socketClient.UnifiedApi.SubscribeToOrderBookUpdatesAsync(_category, Symbol, Levels.Value, ProcessUpdate).ConfigureAwait(false);
            else
                result = await _socketClient.UnifiedApi.SubscribeToOrderBookUpdatesAsync(_category, Symbol, null, ProcessUpdate).ConfigureAwait(false);
            if (!result)
                return result;

            if (ct.IsCancellationRequested)
            {
                await result.Data.CloseAsync().ConfigureAwait(false);
                return result.AsError<UpdateSubscription>(new CancellationRequestedError());
            }

            Status = OrderBookStatus.Syncing;

            var setResult = await WaitForSetOrderBookAsync(TimeSpan.FromMilliseconds(10000), ct).ConfigureAwait(false);
            if (!setResult)
                await result.Data.CloseAsync().ConfigureAwait(false);

            return setResult ? result : new CallResult<UpdateSubscription>(setResult.Error!);
        }

        /// <inheritdoc />
        protected override void DoReset()
        {
            _initial = true;
        }

        private void ProcessUpdate(DataEvent<BitgetUaBookUpdate[]> data)
        {
            var eventData = data.Data.Single();
            if (Levels != null)
            {
                SetSnapshot(eventData.Sequence, eventData.Bids, eventData.Asks, data.DataTime, data.DataTimeLocal);
            }
            else
            {
                if (_initial)
                {
                    _initial = false;
                    SetSnapshot(eventData.Sequence, eventData.Bids, eventData.Asks, data.DataTime, data.DataTimeLocal);
                }
                else
                {
                    UpdateOrderBook(eventData.PreviousSequence, eventData.Sequence, eventData.Bids, eventData.Asks, data.DataTime, data.DataTimeLocal);
                }
            }
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> DoResyncAsync(CancellationToken ct)
        {
            return await WaitForSetOrderBookAsync(TimeSpan.FromSeconds(10), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_clientOwner)
                _socketClient?.Dispose();

            base.Dispose(disposing);
        }
    }
}
