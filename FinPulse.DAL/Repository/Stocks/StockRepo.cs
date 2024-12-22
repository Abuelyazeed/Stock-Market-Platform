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
        
        var stocksList = await stocks.ToListAsync();
        //Sort in memory
        stocksList = userParams.OrderBy switch
        {
            "symbol" => userParams.IsDecsending 
                ? stocksList.OrderByDescending(s => s.Symbol).ToList() 
                : stocksList.OrderBy(s => s.Symbol).ToList(),
            "marketCap" => userParams.IsDecsending 
                ? stocksList.OrderByDescending(s => s.MarketCap).ToList() 
                : stocksList.OrderBy(s => s.MarketCap).ToList(),
            "lastDiv" => userParams.IsDecsending 
                ? stocksList.OrderByDescending(s => s.LastDiv).ToList() 
                : stocksList.OrderBy(s => s.LastDiv).ToList(),
            "purchase" => userParams.IsDecsending 
                ? stocksList.OrderByDescending(s => s.Purchase).ToList() 
                : stocksList.OrderBy(s => s.Purchase).ToList(),
            _ => userParams.IsDecsending 
                ? stocksList.OrderByDescending(s => s.CompanyName).ToList() 
                : stocksList.OrderBy(s => s.CompanyName).ToList(),
        };

        return stocksList;
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