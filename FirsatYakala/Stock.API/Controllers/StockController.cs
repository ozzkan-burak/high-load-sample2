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
    }
}
