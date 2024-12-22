namespace FinPulse.DAL;

public interface IStockRepo
{
    Task<List<Stock>> GetStocksAsync(UserParams userParams);
    Task<Stock?> GetStockAsync(int id);

    Task CreateStockAsync(Stock stock);

    void UpdateStockAsync(Stock stock);

    void DeleteStockAsync(Stock stock);
    Task<int> SaveChanges();
}
