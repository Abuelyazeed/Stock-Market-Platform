namespace FinPulse.DAL;

public interface IStockRepo
{
    List<Stock> GetAllStocks();
    Stock? GetStockById(Guid id);

    void CreateStock(Stock stock);
    
    void UpdateStock(Stock stock);
    int SaveChanges();
}