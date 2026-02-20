using Microsoft.AspNetCore.Mvc;
using StoreAPI.Entities;

[ApiController]

[Route("api/[controller]")]
public class CartItemsController : ControllerBase
{
    private readonly ICartItemService _service;

    public CartItemsController(ICartItemService service)
    {
        _service = service;
}



    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }



    [HttpPost]
    public async Task<IActionResult> Create(CartItem item) => Ok(await _service.CreateAsync(item));



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CartItem item)
    {
        if (id != item.Id) return BadRequest();
        await _service.UpdateAsync(item);
        return NoContent();
    }




    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
