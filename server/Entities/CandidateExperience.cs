namespace server.Entities;

public class CandidateExperience
{
    public int CandidateExperienceId { get; set; }


    public int CandidateId { get; set; }


    public string CompanyName { get; set; }
        = string.Empty;


    public string Position { get; set; }
        = string.Empty;


    public string? Description { get; set; }


    public DateTime? StartDate { get; set; }


    public DateTime? EndDate { get; set; }



    public Candidate Candidate { get; set; } = null!;
}