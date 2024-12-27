using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL.Repository.Portfolio;

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
}