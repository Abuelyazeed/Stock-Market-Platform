namespace FinPulse.DAL;

public interface IPortfolioRepo
{ 
    Task<List<Stock>> GetPortfolio(string userId);
    Task<Portfolio> AddStockToPortfolio(Portfolio portfolio);
}