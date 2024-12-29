using FinPulse.DAL;

namespace FinPulse.BL;

public interface IFmpService
{
    Task<Stock?> FindStockBySymbolAsync(string symbol);
}