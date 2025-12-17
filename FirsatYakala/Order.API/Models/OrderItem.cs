namespace Order.API.Models;

public class OrderItem
{
  public int Id { get; set; }
  public string ProductId { get; set; } = string.Empty;
  public string ProductName { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public int OrderId { get; set; }
}