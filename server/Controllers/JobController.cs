using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Job;
using server.Services.Interfaces;


namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RecruitmentTeam")]
public class JobController : ControllerBase
{

    private readonly IJobService _service;


    public JobController(IJobService service)
    {
        _service = service;
    }





    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _service.GetAllAsync();

        return Ok(jobs);
    }





    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {

        var job = await _service.GetByIdAsync(id);


        if(job == null)
            return NotFound();


        return Ok(job);
    }






    [HttpPost]
    [Authorize(Policy = "RecruitmentTeam")]
    public async Task<IActionResult> Create(CreateJobDto dto)
    {

        var job = await _service.CreateAsync(dto);


        return Ok(job);

    }







    [HttpPut("{id}")]
    [Authorize(Policy = "RecruitmentTeam")]
    public async Task<IActionResult> Update(
        int id,
        UpdateJobDto dto)
    {

        var result = await _service.UpdateAsync(id,dto);


        if(!result)
            return NotFound();


        return Ok("Job updated successfully");

    }






    [HttpDelete("{id}")]
    [Authorize(Policy = "AdministratorOnly")]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _service.DeleteAsync(id);


        if(!result)
            return NotFound();


        return Ok("Job deleted successfully");

    }

}