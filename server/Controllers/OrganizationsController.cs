using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Features.Organization.DTOs;
using server.Features.Organization.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/Organization")]
//[Authorize(Policy = "AdministratorOnly")]
[AllowAnonymous]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _service;

    public OrganizationsController(
        IOrganizationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var organization = await _service.GetByIdAsync(id);

        if (organization == null)
            return NotFound();

        return Ok(organization);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateOrganizationRequest request)
    {
        var organization = await _service.CreateAsync(request);

        return Ok(organization);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateOrganizationRequest request)
    {
        if (!await _service.UpdateAsync(id, request))
            return NotFound();

        return NoContent();
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _service.DeleteAsync(id))
            return NotFound();

        return NoContent();
    }
}