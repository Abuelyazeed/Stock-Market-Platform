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

        //Filter byy symbol
        if (!string.IsNullOrWhiteSpace(userParams.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.ToLower().Contains(userParams.Symbol.ToLower()));
        }
        
        //Filter by company name
        if (!string.IsNullOrWhiteSpace(userParams.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.ToLower().Contains(userParams.CompanyName.ToLower()));
        }
        
        //Sort
        stocks = userParams.OrderBy switch
        {
            "companyName" => userParams.IsDecsending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName),
            "marketCap" => userParams.IsDecsending ? stocks.OrderByDescending(s => s.MarketCap) : stocks.OrderBy(s => s.MarketCap),
            "lastDiv" => userParams.IsDecsending ? stocks.OrderByDescending(s => s.LastDiv) : stocks.OrderBy(s => s.LastDiv),
            "purchase" => userParams.IsDecsending ? stocks.OrderByDescending(s => s.Purchase) : stocks.OrderBy(s => s.Purchase),
            _ => userParams.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol),
        };
        //Pagination
        var skipNumber = (userParams.PageNumber - 1) * userParams.PageSize;
        
        return await stocks.Skip(skipNumber).Take(userParams.PageSize).ToListAsync();
    }

    public async Task<Stock?> GetStockAsync(int id)
    {
        return await _context.Stocks
            .Include(c => c.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Stock?> GetStockBySymbol(string symbol)
    {
        return await _context.Stocks.FirstOrDefaultAsync(x => x.Symbol.ToLower() == symbol.ToLower());
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