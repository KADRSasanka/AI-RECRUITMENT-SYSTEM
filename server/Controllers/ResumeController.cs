using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Resume;
using server.Interfaces;

namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResumeController : ControllerBase
{

    private readonly IResumeService _service;


    public ResumeController(
        IResumeService service)
    {
        _service = service;
    }



    [HttpPost("upload")]
    public async Task<IActionResult> Upload(
        [FromForm] UploadResumeDto dto)
    {

        try
        {
            var result =
                await _service.UploadAsync(dto);


            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(
                new
                {
                    message = ex.Message
                });
        }
    }





    [HttpGet("candidate/{candidateId}")]
    public async Task<IActionResult> 
        GetByCandidate(int candidateId)
    {

        var result =
            await _service
            .GetByCandidateIdAsync(candidateId);


        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult>
        Delete(int id)
    {

        var result =
            await _service.DeleteAsync(id);



        if(!result)
            return NotFound();



        return Ok(
            new
            {
                message =
                "Resume deleted successfully."
            });
    }

}