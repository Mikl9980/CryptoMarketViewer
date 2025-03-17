using System.Threading.Tasks;

namespace CryptoMarketViewer.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<decimal?> GetPriceAsync(string symbol);
    }
}
