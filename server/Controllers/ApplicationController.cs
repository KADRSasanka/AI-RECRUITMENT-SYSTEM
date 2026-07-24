using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Application;
using server.DTOs.Manager;
using server.Interfaces;


namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
//[Authorize]
[AllowAnonymous]
public class ApplicationController : ControllerBase
{

    private readonly IApplicationService _service;


    public ApplicationController(IApplicationService service)
    {
        _service = service;
    }






    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        return Ok(
            await _service.GetAllAsync()
        );

    }







    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var application =
            await _service.GetByIdAsync(id);



        if(application == null)
            return NotFound();



        return Ok(application);

    }








    [HttpGet("candidate/{candidateId}")]
    public async Task<IActionResult> GetByCandidate(
        int candidateId)
    {

        return Ok(
            await _service.GetByCandidateIdAsync(candidateId)
        );

    }








    [HttpGet("job/{jobId}")]
    public async Task<IActionResult> GetByJob(
        int jobId)
    {

        return Ok(
            await _service.GetByJobIdAsync(jobId)
        );

    }








    [HttpPost]
    public async Task<IActionResult> Create(
        CreateApplicationDto dto)
    {

        var result =
            await _service.CreateAsync(dto);


        return Ok(result);

    }








    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateApplicationDto dto)
    {

        var result =
            await _service.UpdateAsync(id,dto);



        if(!result)
            return NotFound();



        return Ok(
            "Application updated successfully"
        );

    }

    [HttpPut("manager-review/{id}")]
    [Authorize(Roles = "Hiring Manager")]
    public async Task<IActionResult> ManagerReview(
        int id,
        ManagerReviewDto dto)
    {
        var result = await _service.ManagerReviewAsync(id, dto);

        if (!result)
            return NotFound();

        return Ok();
    }

}