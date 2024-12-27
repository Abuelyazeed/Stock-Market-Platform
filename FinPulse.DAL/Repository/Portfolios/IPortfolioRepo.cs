namespace FinPulse.DAL.Repository.Portfolio;

public interface IPortfolioRepo
{ 
    Task<List<Stock>> GetPortfolio(string userId);
}