using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;


namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AIController : ControllerBase
{

    private readonly IAIMatchingService _service;



    public AIController(
        IAIMatchingService service)
    {
        _service = service;
    }





    [HttpGet("candidate/{candidateId}/job/{jobId}")]
    public async Task<IActionResult> Analyze(
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