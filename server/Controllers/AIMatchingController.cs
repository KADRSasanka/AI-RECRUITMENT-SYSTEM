using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;


namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize(Roles="Administrator,Recruiter")]
public class AIMatchingController 
    : ControllerBase
{

    private readonly IAIMatchingService _service;


    public AIMatchingController(
        IAIMatchingService service)
    {
        _service = service;
    }



    [HttpPost("{candidateId}/{jobId}")]
    public async Task<IActionResult>
        Analyze(
            int candidateId,
            int jobId)
    {

        var result =
            await _service
            .AnalyzeCandidateAsync(
                candidateId,
                jobId);


        return Ok(result);

    }

}