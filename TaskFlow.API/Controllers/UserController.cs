using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.UserDtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }


    [HttpPut("{id}/role")]
    public async Task<IActionResult> ChangeRole(string id, ChangeRoleDto dto)
    {
        await _userService.ChangeRoleAsync(id, dto.Role);

        return Ok(new
        {
            Message = "Role Updated Successfully"
        });
    }


    [HttpPut("{id}/lock")]
    public async Task<IActionResult> Lock(string id)
    {
        await _userService.LockAsync(id);

        return Ok(new
        {
            Message = "User Locked"
        });
    }


    [HttpPut("{id}/unlock")]
    public async Task<IActionResult> Unlock(string id)
    {
        await _userService.UnlockAsync(id);

        return Ok(new
        {
            Message = "User Unlocked"
        });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userService.DeleteAsync(id);

        return NoContent();
    }
}
