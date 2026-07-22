using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;


namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResumeParserController : ControllerBase
{

    private readonly IResumeParserService _service;


    public ResumeParserController(
        IResumeParserService service)
    {
        _service = service;
    }



    [HttpPost("{resumeId}")]
    public async Task<IActionResult>
        Parse(int resumeId)
    {

        var result =
            await _service
            .ParseResumeAsync(resumeId);


        return Ok(result);
    }

}