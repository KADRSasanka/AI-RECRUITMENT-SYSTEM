namespace server.DTOs.Candidate;

public class CandidateResponseDto
{

    public int CandidateId { get; set; }


    public int UserId { get; set; }


    public string? CurrentPosition { get; set; }


    public string? CurrentCompany { get; set; }


    public int YearsOfExperience { get; set; }


    public string? ProfileSummary { get; set; }


    public DateTime CreatedAt { get; set; }

}