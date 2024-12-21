using FinPulse.DAL;

namespace FinPulse.BL;

public class StockManager : IStockManager
{
    private readonly IStockRepo _stockRepo;

    public StockManager(IStockRepo stockRepo)
    {
        _stockRepo = stockRepo;
    }

    public async Task<List<StockDto>> GetStocksAsync()
    {
        List<Stock> stocks = await _stockRepo.GetStocksAsync();
        
        //List to List
        List<StockDto> stockReadDtos = stocks.Select(stock => new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId
            }).ToList(),
        }).ToList();

        return stockReadDtos;
    }

    public async Task<StockDto?> GetStockAsync(int id)
    {
        Stock? stock = await _stockRepo.GetStockAsync(id);
        if (stock == null) return null;

        return new StockDto()
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId
            }).ToList(),
        };
    }

    public async Task<int> CreateStockAsync(StockCreateDto stockToCreate)
    {
        Stock stock = new Stock()
        {
            // Id = Guid.NewGuid(),
            Symbol = stockToCreate.Symbol,
            CompanyName = stockToCreate.CompanyName,
            Purchase = stockToCreate.Purchase,
            LastDiv = stockToCreate.LastDiv,
            Industry = stockToCreate.Industry,
            MarketCap = stockToCreate.MarketCap

        };
        await _stockRepo.CreateStockAsync(stock);
        await _stockRepo.SaveChanges();

        return stock.Id;
    }

    public async Task<StockDto?> UpdateStockAsync(StockUpdateDto stockUpdateDto,int id)
    {
        Stock? stock = await _stockRepo.GetStockAsync(id);
        
        if(stock == null) return null;
        
        stock.Symbol = stockUpdateDto.Symbol;
        stock.CompanyName = stockUpdateDto.CompanyName;
        stock.Purchase = stockUpdateDto.Purchase;
        stock.LastDiv = stockUpdateDto.LastDiv;
        stock.Industry = stockUpdateDto.Industry;
        stock.MarketCap = stockUpdateDto.MarketCap;

        await _stockRepo.SaveChanges();
        
        return new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId
            }).ToList(),
        };
    }

    public async Task<bool> DeleteStockAsync(int id)
    {
        Stock? stock = await _stockRepo.GetStockAsync(id);
        if (stock == null) return false;
        
        _stockRepo.DeleteStockAsync(stock);
        await _stockRepo.SaveChanges();
        return true;
    }
}