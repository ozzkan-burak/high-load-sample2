using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using Product.API.Services;

namespace Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly ProductService _productService;

  public ProductsController(ProductService productService)
  {
    _productService = productService;
  }
  [HttpGet]
  public async Task<List<Models.Product>> Get() => await _productService.GetAsync();
  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Models.Product>>Get(string id)
  {
    var product = await _productService.GetAsync(id);
    if (product is null) return NotFound();
    return Ok(product);
    
  }
  [HttpPost]
  public async Task<IActionResult> Post(Models.Product newProduct)
  {
    await _productService.CreateAsync(newProduct);
    return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
    
  }
}