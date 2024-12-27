using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class PortfolioRepo : IPortfolioRepo
{
    private readonly FinPulseContext _context;

    public PortfolioRepo(FinPulseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stock>> GetPortfolio(string userId)
    {
        return await _context.Portfolios.Where(x => x.AppUserId == userId)
            .Include(x => x.Stock)
            .ThenInclude(x => x.Comments)
            .Select(x => x.Stock)
            .ToListAsync();
    }

    public async Task<Portfolio> AddStockToPortfolio(Portfolio portfolio)
    {
         await _context.Portfolios.AddAsync(portfolio);
         await _context.SaveChangesAsync();
         return portfolio;
    }
}