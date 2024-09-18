namespace FinPulse.DAL;

public interface IStockRepo
{
    List<Stock> GetAllStocks();
    Stock? GetStockById(Guid id);
    int SaveChanges();
}