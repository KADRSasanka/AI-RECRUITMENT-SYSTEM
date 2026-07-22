namespace server.DTOs.Resume;

public class ResumeResponseDto
{
    public int ResumeId { get; set; }

    public string FileName { get; set; } = "";

    public long FileSize { get; set; }

    public DateTime UploadedAt { get; set; }
}