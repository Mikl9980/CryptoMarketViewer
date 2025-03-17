using Kucoin.Net.Clients;
using System.Threading.Tasks;
using CryptoMarketViewer.Services.Interfaces;

namespace CryptoMarketViewer.Services
{
    public class KucoinService : IExchangeService
    {
        public async Task<decimal?> GetPriceAsync(string symbol)
        {
            var client = new KucoinClient();
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);
            return ticker.Data?.LastPrice;
        }
    }
}
