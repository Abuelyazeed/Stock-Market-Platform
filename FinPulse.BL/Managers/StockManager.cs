using FinPulse.DAL;

namespace FinPulse.BL;

public class StockManager : IStockManager
{
    private readonly IStockRepo _stockRepo;

    public StockManager(IStockRepo stockRepo)
    {
        _stockRepo = stockRepo;
    }

    public List<StockReadDto> GetAllStocks()
    {
        List<Stock> stocks = _stockRepo.GetAllStocks();
        
        //List to List
        List<StockReadDto> stockReadDtos = stocks.Select(stock => new StockReadDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
        }).ToList();

        return stockReadDtos;
    }

    public StockReadDto? GetStockById(Guid id)
    {
        Stock stock = _stockRepo.GetStockById(id);

        return new StockReadDto()
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
        };
    }
}