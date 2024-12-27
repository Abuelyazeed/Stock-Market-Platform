using FinPulse.DAL;
using FinPulse.DAL.Repository.Portfolio;

namespace FinPulse.BL.Managers.Portfolios;

public class PortfolioManager : IPortfolioManager
{
    private readonly IPortfolioRepo _portfolioRepo;

    public PortfolioManager(IPortfolioRepo portfolioRepo)
    {
        _portfolioRepo = portfolioRepo;
    }
    public async Task<List<StockDto>> GetPorfolioAsync(string userId)
    {
        List<Stock> stocks = await _portfolioRepo.GetPortfolio(userId);
        
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
}