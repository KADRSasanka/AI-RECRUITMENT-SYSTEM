namespace server.DTOs.AI;


public class CandidateMatchResponseDto
{

    public int CandidateMatchId { get; set; }


    public int CandidateId { get; set; }


    public int JobId { get; set; }


    public decimal MatchScore { get; set; }


    public string Strengths { get; set; }
        = "";


    public string MissingSkills { get; set; }
        = "";


    public string Recommendation { get; set; }
        = "";

}