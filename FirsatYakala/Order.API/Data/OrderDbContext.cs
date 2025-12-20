using Microsoft.EntityFrameworkCore;
using Order.API.Models;

namespace Order.API.Data;

public class OrderDbContext : DbContext
{
  public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
  {
  }
  public DbSet<Models.Order> Orders {get; set;}
  public DbSet<OrderItem> OrderItems {get; set;}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Models.Order>().OwnsOne(o => o.Address);
    base.OnModelCreating(modelBuilder);
  }
}