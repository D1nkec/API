using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}
