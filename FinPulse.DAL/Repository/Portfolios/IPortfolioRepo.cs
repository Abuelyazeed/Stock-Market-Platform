namespace FinPulse.DAL;

public interface IPortfolioRepo
{ 
    Task<List<Stock>> GetPortfolioStocksAsync(string userId);
    
    Task<Portfolio?> GetPortfolioAsync(string userId, string symbol);
    Task<Portfolio> AddStockToPortfolioAsync(Portfolio portfolio);
    void RemoveStockFromPortfolio(Portfolio portfolio);
    Task<int> SaveChangesAsync();
}