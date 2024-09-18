using FinPulse.DAL;

namespace FinPulse.BL;

public interface IStockManager
{
    List<StockReadDto> GetAllStocks();
    StockReadDto? GetStockById(Guid id);
}