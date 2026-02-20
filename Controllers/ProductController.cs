using Microsoft.AspNetCore.Mvc;
using StoreAPI.Entities;

[ApiController]

[Route("api/[controller]")]


public class ProductsController : ControllerBase
{
private readonly IProductService _service;

public ProductsController(IProductService service)
    {
        _service = service;
    }



    [HttpGet]
public async Task<IActionResult> GetAll()
    {        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
 if (product == null)            return NotFound();

        return Ok(product);}



    [HttpPost]  public async Task<IActionResult> Create(Product product)
    {
        var createdProduct = await _service.CreateAsync(product);

    return CreatedAtAction(
            nameof(GetById),
    new { id = createdProduct.Id },
              createdProduct
        );
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.Id)
                return BadRequest();

        await _service.UpdateAsync(product);
 return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
 return NoContent();
    }
}
