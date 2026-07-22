using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.User;
using server.Service.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("{id}/role")]
    public async Task<IActionResult> UpdateRole(
        int id,
        UpdateUserRoleRequest request)
    {
        var success = await _service.UpdateRoleAsync(id, request);

        if (!success)
            return NotFound();

        return Ok(new
        {
            message = "User role updated successfully."
        });
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        UpdateUserStatusRequest request)
    {
        var success = await _service.UpdateStatusAsync(id, request);

        if (!success)
            return NotFound();

        return Ok(new
        {
            message = "User status updated successfully."
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            message = "User deleted successfully."
        });
    }
}