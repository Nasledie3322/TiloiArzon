using Microsoft.AspNetCore.Mvc;
using StoreAPI.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddUserDto dto)
    {
        var user = new User
        {
            Email = dto.Email,
            PasswordHash = dto.Password,
            Role = "User"
        };

        var created = await _service.AddAsync(user);

        var result = new UserDto
        {
            Id = created.Id,
            Email = created.Email,
            Role = created.Role
        };

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserDto dto)
    {
        var user = await _service.GetByIdAsync(dto.Id);
        if (user == null)
            return NotFound();

        user.Email = dto.Email;
        user.Role = dto.Role;

        await _service.UpdateAsync(user);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();

        var result = users.Select(x => new UserDto
        {
            Id = x.Id,
            Email = x.Email,
            Role = x.Role
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _service.GetByIdAsync(id);
        if (user == null)
            return NotFound();

        var result = new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role
        };

        return Ok(result);
    }
}