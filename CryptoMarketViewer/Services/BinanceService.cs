using Binance.Net.Clients;
using CryptoMarketViewer.Services.Interfaces;
using System.Threading.Tasks;

namespace CryptoMarketViewer.Services
{
    public class BinanceService : IExchangeService
    {
        public async Task<decimal?> GetPriceAsync(string symbol)
        {
            var client = new BinanceClient();
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);
            return ticker.Data?.LastPrice;
        }
    }
}
