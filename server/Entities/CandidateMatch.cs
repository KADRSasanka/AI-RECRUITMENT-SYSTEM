using System.ComponentModel.DataAnnotations;

namespace server.Entities;

public class CandidateMatch
{
    [Key]
    public int CandidateMatchId { get; set; }


    public int CandidateId { get; set; }


    public int JobId { get; set; }


    public decimal MatchScore { get; set; }


    public string Strengths { get; set; }
        = string.Empty;


    public string MissingSkills { get; set; }
        = string.Empty;


    public string Recommendation { get; set; }
        = string.Empty;


    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;


    public Candidate? Candidate { get; set; }


    public Job? Job { get; set; }
}