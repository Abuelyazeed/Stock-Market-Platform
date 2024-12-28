using FinPulse.DAL;

namespace FinPulse.BL;

public interface IPortfolioManager
{
    Task<List<StockDto>> GetPortfolioAsync(string userId);
    
    Task<Portfolio> AddStockToPortfolioAsync(Portfolio portfolio);
    
    Task<bool> RemoveStockFromPortfolioAsync(string userId, string symbol);
}