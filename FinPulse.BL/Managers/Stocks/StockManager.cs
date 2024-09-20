using FinPulse.DAL;

namespace FinPulse.BL;

public class StockManager : IStockManager
{
    private readonly IStockRepo _stockRepo;

    public StockManager(IStockRepo stockRepo)
    {
        _stockRepo = stockRepo;
    }

    public async Task<List<StockReadDto>> GetAllStocksAsync()
    {
        List<Stock> stocks = await _stockRepo.GetAllStocksAsync();
        
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

    public async Task<StockReadDto?> GetStockByIdAsync(Guid id)
    {
        Stock? stock = await _stockRepo.GetStockByIdAsync(id);
        if (stock == null) return null;

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

    public async Task CreateStockAsync(StockCreateDto stockToCreate)
    {
        Stock stock = new Stock()
        {
            Id = Guid.NewGuid(),
            Symbol = stockToCreate.Symbol,
            CompanyName = stockToCreate.CompanyName,
            Purchase = stockToCreate.Purchase,
            LastDiv = stockToCreate.LastDiv,
            Industry = stockToCreate.Industry,
            MarketCap = stockToCreate.MarketCap

        };
        await _stockRepo.CreateStockAsync(stock);
        await _stockRepo.SaveChanges();
    }

    public async Task<bool> UpdateStockAsync(StockUpdateDto stockUpdateDto,Guid id)
    {
        Stock? stock = await _stockRepo.GetStockByIdAsync(id);
        if (stock == null) return false;
        
        stock.Symbol = stockUpdateDto.Symbol;
        stock.CompanyName = stockUpdateDto.CompanyName;
        stock.Purchase = stockUpdateDto.Purchase;
        stock.LastDiv = stockUpdateDto.LastDiv;
        stock.Industry = stockUpdateDto.Industry;
        stock.MarketCap = stockUpdateDto.MarketCap;
        
        int numberOfAffectedRows = await _stockRepo.SaveChanges();
        return numberOfAffectedRows > 0;
    }

    public async Task<bool> DeleteStockAsync(Guid id)
    {
        Stock? stock = await _stockRepo.GetStockByIdAsync(id);
        if (stock == null) return false;
        
        _stockRepo.DeleteStockAsync(stock);
        await _stockRepo.SaveChanges();
        return true;
    }
}