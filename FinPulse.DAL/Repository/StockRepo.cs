namespace FinPulse.DAL;

public class StockRepo : IStockRepo
{
    private readonly FinPulseContext _context;
    
    public StockRepo(FinPulseContext context)
    {
        _context = context;
    }


    public List<Stock> GetAllStocks()
    {
        return _context.Stocks.ToList();
    }

    public Stock? GetStockById(Guid id)
    {
        return _context.Stocks.FirstOrDefault(x => x.Id == id);
    }

    public void CreateStock(Stock stock)
    {
        _context.Stocks.Add(stock);
    }

    public void UpdateStock(Stock stock)
    {
       // _context.Update(stock);
    }

    public void DeleteStock(Stock stock)
    {
        _context.Stocks.Remove(stock);
    }


    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}