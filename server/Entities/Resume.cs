namespace server.Entities;

public class Resume
{
    public int ResumeId { get; set; }

    public int CandidateId { get; set; }

    public string FileName { get; set; }
        = string.Empty;

    public string StoredFileName { get; set; }
        = string.Empty;

    public string FilePath { get; set; }
        = string.Empty;

    public long FileSize { get; set; }

    public string ContentType { get; set; }
        = string.Empty;

    public DateTime UploadedAt { get; set; }
        = DateTime.UtcNow;

    public Candidate Candidate { get; set; } = null!;

    public ResumeProfile? ResumeProfile { get; set; }
}