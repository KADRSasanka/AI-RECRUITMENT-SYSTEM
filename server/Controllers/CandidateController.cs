using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Candidate;
using server.Services.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    // GET: api/candidate
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var candidates = await _candidateService.GetAllAsync();
        return Ok(candidates);
    }

    // GET: api/candidate/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var candidate = await _candidateService.GetByIdAsync(id);

        if (candidate == null)
            return NotFound();

        return Ok(candidate);
    }

    // GET: api/candidate/dashboard
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {

        var candidateId = int.Parse(
            User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier
            )!.Value
        );


        var dashboard =
            await _candidateService.GetDashboardAsync(candidateId);


        return Ok(dashboard);

    }

    // POST: api/candidate
    [HttpPost]
    public async Task<IActionResult> Create(CreateCandidateDto dto)
    {
        var candidate = await _candidateService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = candidate.CandidateId },
            candidate);
    }

    // PUT: api/candidate/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCandidateDto dto)
    {
        var updated = await _candidateService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/candidate/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _candidateService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}