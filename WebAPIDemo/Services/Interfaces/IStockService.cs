using Microsoft.OpenApi.Models;
using WebAPIDemo.Dtos.Stock;
using WebAPIDemo.Helpers;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Interfaces
{
    public interface IStockService
    {

        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> GetByIdAsync(int id); // FirstOrDefault can be null

        Task<Stock?> GetBySymbolAsync(string symbol);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExist(int id);
    }
}
