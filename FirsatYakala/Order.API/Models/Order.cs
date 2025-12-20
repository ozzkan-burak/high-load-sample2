using Order.API.Enums;

namespace Order.API.Models;

public class Order
{
  public DateTime CreatedDate {get; set;}
  public int Id { get; set; }
  public string BuyerId { get; set; } = string.Empty;
  public List<OrderItem> Items {get; set;} = new();
  public Address Address { get; set; } = new();
  public OrderStatus Status {get; set;} = OrderStatus.Suspend;
  public decimal TotalPrice => Items.Sum(x => x.Price);
}