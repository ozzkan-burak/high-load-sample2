using Order.API.Enums;

namespace Order.API.Models;

public class Order
{
  public DateTime CreatedDate {get; set;}
  public string Id { get; set; } = string.Empty;
  public string BuyerId { get; set; } = string.Empty;
  public List<OrederItem> Items {get; set;} = new();
  public OrderStatus Status {get; set;} = OrderStatus.Suspend;
  public decimal TotalPrice => Items.Sum(x => x.Price);
}