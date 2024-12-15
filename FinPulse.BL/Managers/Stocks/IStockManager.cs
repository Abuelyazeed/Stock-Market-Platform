
namespace FinPulse.BL;

public interface IStockManager
{
    Task<List<StockDto>> GetStocksAsync();
    Task<StockDto?> GetStockAsync(int id);
    Task CreateStockAsync(StockCreateDto stock);
    Task<bool> UpdateStockAsync(StockUpdateDto stock,int id);
    
    Task<bool> DeleteStockAsync(int id);
}