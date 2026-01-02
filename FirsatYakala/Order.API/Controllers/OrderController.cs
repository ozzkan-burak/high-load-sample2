using Microsoft.AspNetCore.Mvc;
using Order.API.Data;
using Order.API.Models;

namespace Order.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrderController : ControllerBase
  {
    private readonly OrderDbContext _context;
    private readonly HttpClient _httpClient;

    public OrderController(OrderDbContext context, HttpClient httpClient)
    {
      _context = context;
      _httpClient = httpClient;
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(Models.Order order)
    {
      var productId = order.Items.First().ProductId;

      var response = await _httpClient.GetAsync($"http://localhost:5002/api/stocks/{productId}");
      
      if(!response.IsSuccessStatusCode)
      {
        return BadRequest("Stock not found");
      }
      var stockQuantityString = await response.Content.ReadAsStringAsync();
      var stockQuantity = int.Parse(stockQuantityString);

      if(stockQuantity < 1)
      {
        return BadRequest("Stock quantity is not enough");
      }
      order.Status = Enums.OrderStatus.Completed;
      await _context.Orders.AddAsync(order);
      await _context.SaveChangesAsync();
      var decreaseRequest = new 
      { 
        ProductId = productId, 
        Count = 1 
    };
      var decreaseResponse = await _httpClient.PostAsJsonAsync($"http://localhost:5002/api/stocks/decrease-stock", decreaseRequest);
      if(!decreaseResponse.IsSuccessStatusCode)
      {
        return BadRequest("Stock not found");
      }
return Ok(new { OrderId = order.Id, Message = "Sipariş alındı ve stok düşüldü!" });    }
  }
}