using Bybit.Net.Clients;
using CryptoMarketViewer.Services.Interfaces;
using System.Threading.Tasks;

namespace CryptoMarketViewer.Services
{
    public class BybitService : IExchangeService
    {
        public async Task<decimal?> GetPriceAsync(string symbol)
        {
            var client = new BybitClient();
            var ticker = await client.SpotApiV3.ExchangeData.GetTickerAsync(symbol);
            return ticker.Data?.LastPrice;
        }
    }
}
