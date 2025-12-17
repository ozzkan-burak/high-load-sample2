namespace Stock.API.Models;

public class Stock
{
  public int Id { get; set; }
  public string ProductId { get; set; } = string.Empty;
  public int Quantity { get; set; }
}