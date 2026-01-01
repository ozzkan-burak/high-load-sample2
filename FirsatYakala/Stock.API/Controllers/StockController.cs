using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.API.Data;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly StockDbContext _context;
        public StockController(StockDbContext context)
        {
            _context = context;
        }

        // Ürün stoklarını getir
        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks);
        }
        // Stok oluştur (Başlangıç verisi girmek için)
        [HttpPost]
        public async Task<IActionResult> CreateStock(Models.Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return Ok(stock);
        }
        // Stok düşür
        [HttpPost("decrease-stock")]
        public async Task<IActionResult> DecreaseStock([FromBody] StockUpdateDto model)
        {
           var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
           if(stock == null) return NotFound("Stock not found");
           if(stock.Count < model.Count) return BadRequest("Not enough stock");
           stock.Count -= model.Count;
           await _context.SaveChangesAsync();
           return Ok(new {Message = "Stock updated successfully", NewCount = stock.Count});
        }
        
    }
}

public class StockUpdateDto
{
    public string ProductId { get; set; }
    public int Count { get; set; }
}