namespace FinPulse.DAL;

public interface IStockRepo
{
    List<Stock> GetAllStocks();
    Stock? GetStockById(Guid id);

    void CreateStock(Stock stock);
    
    void UpdateStock(Stock stock);
    
    void DeleteStock(Stock stock);
    int SaveChanges();
}