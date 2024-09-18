
namespace FinPulse.BL;

public interface IStockManager
{
    List<StockReadDto> GetAllStocks();
    StockReadDto? GetStockById(Guid id);
    void CreateStock(StockCreateDto stock);
    bool UpdateStock(StockUpdateDto stock,Guid id);
}