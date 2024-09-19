using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class StockRepo : IStockRepo
{
    private readonly FinPulseContext _context;
    
    public StockRepo(FinPulseContext context)
    {
        _context = context;
    }


    public async Task<List<Stock>> GetAllStocks()
    {
        return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetStockById(Guid id)
    {
        return await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateStock(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
    }

    public void UpdateStock(Stock stock)
    {
       // _context.Update(stock);
    }

    public void DeleteStock(Stock stock)
    {
        _context.Stocks.Remove(stock);
    }


    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}