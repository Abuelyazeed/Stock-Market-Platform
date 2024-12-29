
namespace FinPulse.BL;

public interface IStockManager
{
    Task<List<StockDto>> GetStocksAsync(UserParams userParams);
    Task<StockDto?> GetStockAsync(int id);
    Task<StockDto?> GetStockBySymbolAsync(string symbol);
    Task<StockDto> CreateStockAsync(StockCreateDto stock);
    Task<StockDto?> UpdateStockAsync(StockUpdateDto stock,int id);
    Task<StockDto?> EnsureStockExistsAsync(string symbol);
    
    Task<bool> DeleteStockAsync(int id);
}