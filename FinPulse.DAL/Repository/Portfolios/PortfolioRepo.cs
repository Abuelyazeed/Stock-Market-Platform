using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class PortfolioRepo : IPortfolioRepo
{
    private readonly FinPulseContext _context;

    public PortfolioRepo(FinPulseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stock>> GetPortfolioStocksAsync(string userId)
    {
        return await _context.Portfolios.Where(x => x.AppUserId == userId)
            .Include(x => x.Stock)
            .ThenInclude(x => x.Comments)
            .Select(x => x.Stock)
            .ToListAsync();
    }

    public async Task<Portfolio?> GetPortfolioAsync(string userId, string symbol)
    {
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(x => x.AppUserId == userId && x.Stock.Symbol.ToLower() == symbol.ToLower());
        if (portfolio == null) return null;

        return portfolio;
    }

    public async Task<Portfolio> AddStockToPortfolioAsync(Portfolio portfolio)
    {
         await _context.Portfolios.AddAsync(portfolio);
         return portfolio;
    }

    public void RemoveStockFromPortfolio(Portfolio portfolio)
    {
        _context.Remove(portfolio);
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}