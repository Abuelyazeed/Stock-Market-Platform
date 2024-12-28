namespace FinPulse.DAL;

public interface IStockRepo
{
    Task<List<Stock>> GetStocksAsync(UserParams userParams);
    Task<Stock?> GetStockAsync(int id);
    Task<Stock?> GetStockBySymbol(string symbol);

    Task CreateStockAsync(Stock stock);

    void UpdateStockAsync(Stock stock);

    void DeleteStock(Stock stock);
    Task<int> SaveChangesAync();
}
