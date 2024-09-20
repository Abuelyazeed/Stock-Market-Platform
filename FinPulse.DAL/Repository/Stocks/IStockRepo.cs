namespace FinPulse.DAL;

public interface IStockRepo
{
    Task<List<Stock>> GetAllStocksAsync();
    Task<Stock?> GetStockByIdAsync(Guid id);

    Task CreateStockAsync(Stock stock);

    void UpdateStockAsync(Stock stock);

    void DeleteStockAsync(Stock stock);
    Task<int> SaveChanges();
}
