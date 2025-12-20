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
    public OrderController(OrderDbContext context)
    {
      _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(Models.Order order)
    {
      await _context.Orders.AddAsync(order);
      await _context.SaveChangesAsync();
      return Ok(new {OrderId = order.Id});
    }
  }
}