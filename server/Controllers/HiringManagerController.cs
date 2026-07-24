using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Services.Interfaces;

namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize(Roles="Hiring Manager")]
public class HiringManagerController : ControllerBase
{

    private readonly IJobService _jobService;
    private readonly IApplicationService _applicationService;


    public HiringManagerController(
        IJobService jobService,
        IApplicationService applicationService)
    {
        _jobService = jobService;
        _applicationService = applicationService;
    }



    [HttpGet("jobs")]
    public async Task<IActionResult> GetJobs()
    {
        var managerId =
        int.Parse(
        User.FindFirst(
        ClaimTypes.NameIdentifier
        )!.Value
        );


        var jobs =
        await _jobService.GetByHiringManagerAsync(managerId);

        return Ok(jobs);
    }



    [HttpGet("applications")]
    public async Task<IActionResult> GetApplications()
    {
        var applications =
            await _applicationService.GetAllAsync();

        return Ok(applications);
    }

}