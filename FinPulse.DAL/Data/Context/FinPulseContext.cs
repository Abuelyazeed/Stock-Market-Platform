using FinPulse.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL.Data.Context;

public class FinPulseContext : DbContext
{
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Stock> Comments => Set<Stock>();
    
    public FinPulseContext(DbContextOptions<FinPulseContext> options) : base(options)
    {
        
    }
}