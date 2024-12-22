
namespace FinPulse.BL;

public interface IStockManager
{
    Task<List<StockDto>> GetStocksAsync(UserParams userParams);
    Task<StockDto?> GetStockAsync(int id);
    Task<int> CreateStockAsync(StockCreateDto stock);
    Task<StockDto?> UpdateStockAsync(StockUpdateDto stock,int id);
    
    Task<bool> DeleteStockAsync(int id);
}