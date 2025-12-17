using Microsoft.EntityFrameworkCore;

namespace Stock.API.Data;

public class StockDbContext : DbContext
{
  public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
  {
  }

  public DbSet<Models.Stock> Stocks { get; set; }
}