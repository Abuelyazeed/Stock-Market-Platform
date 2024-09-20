using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class FinPulseContext : DbContext
{
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Comment> Comments => Set<Comment>();
    
    public FinPulseContext(DbContextOptions<FinPulseContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seeding stock data

        modelBuilder.Entity<Stock>().HasData(
            new Stock
            {
                Id = Guid.NewGuid(),
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                Purchase = 150.25m,
                LastDiv = 0.22m,
                Industry = "Technology",
                MarketCap = 2500000000000 // 2.5 Trillion USD
            },
            new Stock
            {
                Id = Guid.NewGuid(),
                Symbol = "MSFT",
                CompanyName = "Microsoft Corporation",
                Purchase = 305.12m,
                LastDiv = 0.56m,
                Industry = "Technology",
                MarketCap = 2300000000000 // 2.3 Trillion USD
            },
            new Stock
            {
                Id = Guid.NewGuid(),
                Symbol = "TSLA",
                CompanyName = "Tesla Inc.",
                Purchase = 750.50m,
                LastDiv = 0.00m, // Tesla doesn't pay dividends
                Industry = "Automotive",
                MarketCap = 900000000000 // 900 Billion USD
            }
        );

        #endregion 
        
    }
}