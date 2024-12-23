using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class FinPulseContext(DbContextOptions<FinPulseContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seeding stock data

        modelBuilder.Entity<Stock>().HasData(
            new Stock
            {
                Id = 1,
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                Purchase = 150.25,
                LastDiv = 0.22,
                Industry = "Technology",
                MarketCap =  3000000000// 3 Trillion USD
            },
            new Stock
            {
                Id = 2,
                Symbol = "MSFT",
                CompanyName = "Microsoft Corporation",
                Purchase = 305.12,
                LastDiv = 0.56,
                Industry = "Technology",
                MarketCap = 2300000000// 2.3 Trillion USD
            },
            new Stock
            {
                Id = 3,
                Symbol = "TSLA",
                CompanyName = "Tesla Inc.",
                Purchase = 750.50,
                LastDiv = 0, // Tesla doesn't pay dividends
                Industry = "Automotive",
                MarketCap =  1000000000 // 1 trillion USD
            },
            
            new Stock
            {
                Id = 4,
                Symbol = "AMZN",
                CompanyName = "Amazon",
                Purchase = 750.50,
                LastDiv = 0, // Amazon doesn't pay dividends
                Industry = "Technology",
                MarketCap =  2600000000 // 1 trillion USD
            }
        );

        #endregion 
        
    }
}