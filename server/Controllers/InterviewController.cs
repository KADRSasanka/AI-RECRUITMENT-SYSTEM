using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Interview;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RecruitmentTeam")]

    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _service;

        public InterviewController(IInterviewService service)
        {
            _service = service;
        }

        // GET: api/Interview
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var interviews = await _service.GetAllAsync();
            return Ok(interviews);
        }

        // GET: api/Interview/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interview = await _service.GetByIdAsync(id);

            if (interview == null)
                return NotFound();

            return Ok(interview);
        }

        // POST: api/Interview
        [HttpPost]
        public async Task<IActionResult> Create(CreateInterviewDto dto)
        {
            var createdInterview = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdInterview.InterviewId },
                createdInterview);
        }

        // PUT: api/Interview/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateInterviewDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Interview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}