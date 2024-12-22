using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class StockRepo : IStockRepo
{
    private readonly FinPulseContext _context;
    
    public StockRepo(FinPulseContext context)
    {
        _context = context;
    }


    public async Task<List<Stock>> GetStocksAsync(UserParams userParams)
    {
        var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();

        if (!string.IsNullOrWhiteSpace(userParams.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.ToLower().Contains(userParams.Symbol.ToLower()));
        }
        
        if (!string.IsNullOrWhiteSpace(userParams.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.ToLower().Contains(userParams.CompanyName.ToLower()));
        }
        
        return await stocks.ToListAsync();
    }

    public async Task<Stock?> GetStockAsync(int id)
    {
        return await _context.Stocks
            .Include(c => c.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateStockAsync(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
    }

    public void UpdateStockAsync(Stock stock)
    {
       // _context.Update(stock);
    }

    public void DeleteStockAsync(Stock stock)
    {
        _context.Stocks.Remove(stock);
    }


    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}