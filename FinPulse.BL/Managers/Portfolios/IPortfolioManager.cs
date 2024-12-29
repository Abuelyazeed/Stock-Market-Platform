using FinPulse.DAL;

namespace FinPulse.BL;

public interface IPortfolioManager
{
    Task<List<StockDto>> GetPortfolioAsync(string userId);
    
    Task<Portfolio> AddStockToPortfolioAsync(int stockId, string userId);
    
    Task<bool> RemoveStockFromPortfolioAsync(string userId, string symbol);
}