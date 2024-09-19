
namespace FinPulse.BL;

public interface IStockManager
{
    Task<List<StockReadDto>> GetAllStocksAsync();
    Task<StockReadDto?> GetStockByIdAsync(Guid id);
    Task CreateStockAsync(StockCreateDto stock);
    Task<bool> UpdateStockAsync(StockUpdateDto stock,Guid id);
    
    Task<bool> DeleteStockAsync(Guid id);
}