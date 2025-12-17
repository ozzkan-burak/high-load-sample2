using Microsoft.EntityFrameworkCore;
using Order.API.Models;

namespace Order.API.Dsata;

public class OrderDbContext : DbContext
{
  public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
  {
  }
  public DbSet<Models.Order> Orders {get; set;}
  public DbSet<OrederItem> OrderItems {get; set;}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Model.Oder>().OwnsOne(o => o.Address);
    base.OnModelCreating(modelBuilder);
  }
}