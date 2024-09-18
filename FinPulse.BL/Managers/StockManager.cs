using FinPulse.DAL;

namespace FinPulse.BL;

public class StockManager : IStockManager
{
    private readonly IStockRepo _stockRepo;

    public StockManager(IStockRepo stockRepo)
    {
        _stockRepo = stockRepo;
    }

}