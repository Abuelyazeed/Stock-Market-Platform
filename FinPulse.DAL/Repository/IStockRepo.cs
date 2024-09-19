namespace FinPulse.DAL;

public interface IStockRepo
{
    Task<List<Stock>> GetAllStocks();
    Task<Stock?> GetStockById(Guid id);

    Task CreateStock(Stock stock);
    
    void UpdateStock(Stock stock);
    
    void DeleteStock(Stock stock);
    Task<int> SaveChanges();
}