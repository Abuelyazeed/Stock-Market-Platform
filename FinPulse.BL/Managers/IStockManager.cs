
namespace FinPulse.BL;

public interface IStockManager
{
    Task<List<StockReadDto>> GetAllStocks();
    Task<StockReadDto?> GetStockById(Guid id);
    Task CreateStock(StockCreateDto stock);
    Task<bool> UpdateStock(StockUpdateDto stock,Guid id);
    
    Task<bool> DeleteStock(Guid id);
}