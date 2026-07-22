
namespace server.DTOs.Resume;

public class UploadResumeDto
{
    public int CandidateId { get; set; }

    public IFormFile Resume { get; set; } = null!;
}