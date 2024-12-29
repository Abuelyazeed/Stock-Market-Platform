using FinPulse.DAL;

namespace FinPulse.BL;

public class StockManager : IStockManager
{
    private readonly IStockRepo _stockRepo;
    private readonly IFmpService _fmpService;

    public StockManager(IStockRepo stockRepo, IFmpService fmpService)
    {
        _stockRepo = stockRepo;
        _fmpService = fmpService;
    }

    public async Task<List<StockDto>> GetStocksAsync(UserParams userParams)
    {
        List<Stock> stocks = await _stockRepo.GetStocksAsync(userParams);
        
        //List to List
        List<StockDto> stocksDto = stocks.Select(stock => new StockDto
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
                CreatedBy = c.AppUser!.UserName,
                StockId = c.StockId
            }).ToList(),
        }).ToList();

        return stocksDto;
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
                CreatedBy = c.AppUser!.UserName,
                StockId = c.StockId
            }).ToList(),
        };
    }
    
    public async Task<StockDto?> GetStockBySymbolAsync(string symbol)
    {
        Stock? stock = await _stockRepo.GetStockBySymbol(symbol);
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

    public async Task<StockDto> CreateStockAsync(StockCreateDto stockToCreate)
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
        await _stockRepo.SaveChangesAync();

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
                CreatedBy = c.AppUser!.UserName,
                StockId = c.StockId
            }).ToList(),
        };
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

        await _stockRepo.SaveChangesAync();
        
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

    public async Task<StockDto?> EnsureStockExistsAsync(string symbol)
    {
        //fetch the stock from the external service
        var stock = await _fmpService.FindStockBySymbolAsync(symbol);
        if (stock == null)
            return null; // Stock does not exist

        // Save the stock to the database
        var createdStock = await CreateStockAsync(new StockCreateDto
        {
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap,
        });

        // Map the saved stock to StockDto
        return new StockDto
        {
            Id = createdStock.Id,
            Symbol = createdStock.Symbol,
            CompanyName = createdStock.CompanyName,
            Purchase = createdStock.Purchase,
            LastDiv = createdStock.LastDiv,
            Industry = createdStock.Industry,
            MarketCap = createdStock.MarketCap,
            Comments = createdStock.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId
            }).ToList()
        };
    }


    public async Task<bool> DeleteStockAsync(int id)
    {
        Stock? stock = await _stockRepo.GetStockAsync(id);
        if (stock == null) return false;
        
        _stockRepo.DeleteStock(stock);
        return await _stockRepo.SaveChangesAync() > 0;
    }
}