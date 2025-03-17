using Bitget.Net.Clients;
using CryptoMarketViewer.Services.Interfaces;
using System.Threading.Tasks;

namespace CryptoMarketViewer.Services
{
    public class BitgetService : IExchangeService
    {
        public async Task<decimal?> GetPriceAsync(string symbol)
        {
            var client = new BitgetClient();
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);
            return ticker.Data?.LastPrice;
        }
    }
}