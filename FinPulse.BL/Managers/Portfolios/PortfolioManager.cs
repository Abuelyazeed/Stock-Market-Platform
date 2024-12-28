using FinPulse.DAL;

namespace FinPulse.BL;

public class PortfolioManager : IPortfolioManager
{
    private readonly IPortfolioRepo _portfolioRepo;

    public PortfolioManager(IPortfolioRepo portfolioRepo)
    {
        _portfolioRepo = portfolioRepo;
    }
    public async Task<List<StockDto>> GetPortfolioAsync(string userId)
    {
        List<Stock> stocks = await _portfolioRepo.GetPortfolioStocksAsync(userId);
        
        List<StockDto> stocksDto = stocks.Select(stock => new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId
            }).ToList(),
        }).ToList();

        return stocksDto;
    }

    public async Task<Portfolio> AddStockToPortfolioAsync(Portfolio portfolio)
    {
        var portfolioAdded = await _portfolioRepo.AddStockToPortfolioAsync(portfolio);
        await _portfolioRepo.SaveChangesAsync();
        return portfolioAdded;
    }

    public async Task<bool> RemoveStockFromPortfolioAsync(string userId, string symbol)
    {
        var portfolioToRemove = await _portfolioRepo.GetPortfolioAsync(userId, symbol);
        if(portfolioToRemove == null) return false;
        
        _portfolioRepo.RemoveStockFromPortfolio(portfolioToRemove);
        
        return await _portfolioRepo.SaveChangesAsync() > 0;
    }
}