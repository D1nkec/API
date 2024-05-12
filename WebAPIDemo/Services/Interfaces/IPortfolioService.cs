using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);

        Task<Portfolio> CreateAsync(Portfolio portfolio);

        Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol);
    }
}
