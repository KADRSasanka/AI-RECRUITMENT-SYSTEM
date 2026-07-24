namespace server.DTOs.AI;

public class CandidateMatchResponseDto
{
    public int CandidateId { get; set; }

    public int JobId { get; set; }

    public string CandidateName { get; set; } = "";

    public string JobTitle { get; set; } = "";

    public decimal MatchScore { get; set; }

    public string Recommendation { get; set; } = "";

    public string Strengths { get; set; } = "";

    public string MissingSkills { get; set; } = "";

    public List<string> MatchedKeywords { get; set; }
        = new();
}