using Microsoft.AspNetCore.Mvc;
using StoreAPI.Entities;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _service;

    public FavoritesController(IFavoriteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Favorite favorite)
        => Ok(await _service.CreateAsync(favorite));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
